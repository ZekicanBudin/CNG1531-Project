// **************************************************************************************************
//		CSimulationManager
//
//		generated
//			by		: 	Simulation Generator (SimGe) v.0.3.3
//			at		: 	25 January, 2021 10:45:52 PM
//		compatible with		: 	RACoN v.0.0.2.5
//
//		copyright		: 	(C) 
//		email			: 	
// **************************************************************************************************
/// <summary>
/// The Simulation Manager manages the (multiple) federation execution(s) and the (multiple instances of) joined federate(s).
/// </summary>

// System
using System;
using System.Collections.Generic; // for List
// Racon
using Racon;
using Racon.RtiLayer;
// Application
using DatasetCollection.Som;
using System.ComponentModel;

namespace DatasetCollection
{
    public class CSimulationManager
    {
        #region Declarations
        // Communication layer related structures
        public CHumanFederateApp federate; //Application-specific federate 
                                           // Local data structures
        public string SynchronData;
        #endregion //Declarations
        public BindingList<CHumanHlaObject> obj_list;
        #region Constructor
        public CSimulationManager()
        {
            // Initialize the application-specific federate
            federate = new CHumanFederateApp(this);
            // Initialize the federation execution
            federate.FederationExecution.Name = "DatasetCollection";
            federate.FederationExecution.FederateType = "Sensor";
            federate.FederationExecution.ConnectionSettings = "rti://127.0.0.1";
            // Handle RTI type variation
            initialize();
            federate.LogLevel = LogLevel.ALL;
            federate.InteractionReceived += federate.FdAmb_InteractionReceivedHandler;
            federate.StatusMessageChanged += new EventHandler(StatusMessage);
            federate.FederateStateChanged += Federate_StatusMessageChanged;
            _ = federate.InitializeFederation(federate.FederationExecution);
            federate.FederationExecution.FederateName = DateTime.Now.Ticks.ToString();
            DoSimulation();
        }
        #endregion //Constructor
        private static void Federate_StatusMessageChanged(object sender, EventArgs e)
        {
            Console.WriteLine((sender as CHumanFederateApp).StatusMessage);
        }
        private void StatusMessage(object sender, EventArgs e)
        {
            Console.WriteLine(federate.StatusMessage);
        }
        #region Methods
        // Handles naming variation according to HLA specification
        private void initialize()
        {
            switch (federate.RTILibrary)
            {
                case RTILibraryType.HLA13_DMSO:
                case RTILibraryType.HLA13_Portico:
                case RTILibraryType.HLA13_OpenRti:
                    federate.Som.HumanOC.Name = "objectRoot.Human";
                    federate.Som.HumanOC.PrivilegeToDelete.Name = "privilegeToDelete";
                    federate.Som.MessageIC.Name = "interactionRoot.Message";
                    federate.FederationExecution.FDD = @".\DatasetCollectionFOM.fed";
                    break;
                case RTILibraryType.HLA1516e_Portico:
                case RTILibraryType.HLA1516e_OpenRti:
                    federate.Som.HumanOC.Name = "HLAobjectRoot.Human";
                    federate.Som.HumanOC.PrivilegeToDelete.Name = "HLAprivilegeToDeleteObject";
                    federate.Som.MessageIC.Name = "HLAinteractionRoot.Message";
                    federate.FederationExecution.FDD = @".\DatasetCollectionFOM.xml";
                    break;
            }
        }
        public bool SendMessage(string s)
        {
            try
            {
                Racon.RtiLayer.HlaInteraction interaction = new Racon.RtiLayer.HlaInteraction(federate.Som.MessageIC, "Content");
                interaction.AddParameterValue(federate.Som.MessageIC.Content, "Human_" + s);
                return federate.SendInteraction(interaction, "");
            }
            catch
            {
                return false;
            }
        }
        private void DoSimulation()
        {
            federate.DeclareCapability();
            if (federate.FederateState.HasFlag(Racon.FederateStates.JOINED))
            {
                federate.Run();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter 0 to exit!");
            string input = Console.ReadLine();

            while (true)
            {
                federate.Run();
                if (input.CompareTo("0") == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    federate.FinalizeFederation(federate.FederationExecution, Racon.ResignAction.NO_ACTION);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    //Send interaction
                    if (SendMessage(input))
                    {
                        Console.WriteLine("SENT> " + input + Environment.NewLine);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        SynchronData = "Human_"+input;
                        federate.RegisterFederationSynchronizationPoint(SynchronData, "Appended");
                    }
                    federate.Run();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter 0 to exit!");
                    input = Console.ReadLine();
                    federate.Run();
                }
            }
        }
        #endregion //Methods
    }
}
