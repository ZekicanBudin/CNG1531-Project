// **************************************************************************************************
//		CSensorFederateApp
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
/// The application specific federate that is extended from the Generic Federate Class of RACoN API. This file is intended for manual code operations.
/// </summary>

// System
using System;
using System.Collections.Generic; // for List
// Racon
using Racon;
using Racon.RtiLayer;
// Application
using DatasetCollection.Som;

namespace DatasetCollection
{
    public partial class CSensorFederateApp : Racon.CGenericFederate
    {
        #region Manually Added Code

        // Local Data
        private CSimulationManager manager;

        #region Constructor
        public CSensorFederateApp(CSimulationManager parent) : this()
        {
            manager = parent; // Set simulation manager
                              // Create regions manually
        }
        #endregion //Constructor
        public override void FdAmb_TurnInteractionsOnAdvisedHandler(object sender, HlaDeclarationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_TurnInteractionsOnAdvisedHandler(sender, data);

            #region User Code
            Console.WriteLine("Can send interactions.");
            //throw new NotImplementedException("FdAmb_TurnInteractionsOnAdvisedHandler");
            #endregion //User Code
        }

        // FdAmb_InteractionReceivedHandler
        public override void FdAmb_InteractionReceivedHandler(object sender, HlaInteractionEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_InteractionReceivedHandler(sender, data);

            #region User Code
            string con = data.GetParameterValue<string>(Som.MessageIC.Content);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("RECEIVED>" + con);
            #endregion //User Code
        }
        public override void FdAmb_StartRegistrationForObjectClassAdvisedHandler(object sender, HlaDeclarationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_StartRegistrationForObjectClassAdvisedHandler(sender, data);
            
            #region User Code
            //throw new NotImplementedException("FdAmb_StartRegistrationForObjectClassAdvisedHandler");
            #endregion //User Code
        }
        public override void FdAmb_ObjectDiscoveredHandler(object sender, HlaObjectEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_ObjectDiscoveredHandler(sender, data);
            if (data.ClassHandle == Som.SensorOC.Handle)
            {
                CSensorHlaObject datacollection = new CSensorHlaObject(data.ObjectInstance);
                datacollection.Type = Som.SensorOC;
                manager.obj_list.Add(datacollection);
                RegisterHlaObject(datacollection);
                Console.WriteLine("A new object joined");

            }
            #region User Code
            //throw new NotImplementedException("FdAmb_ObjectDiscoveredHandler");
            #endregion //User Code
        }
        public override void FdAmb_OnSynchronizationPointRegistrationConfirmedHandler(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_OnSynchronizationPointRegistrationConfirmedHandler(sender, data);

            #region User Code
            //Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" @@@@@ ({data.Label}) is registered. @@@@@@" + Environment.NewLine);
            Console.WriteLine($"Registered Syncronized Data: {manager.SynchronData}");
            #endregion //User Code
        }
        public override void FdAmb_SynchronizationPointAnnounced(object sender, HlaFederationManagementEventArgs data)
        {
            // Call the base class handler
            base.FdAmb_SynchronizationPointAnnounced(sender, data);

            #region User Code
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($" @@@@@@ ({data.Label}) is announced. @@@@@@ " + Environment.NewLine);
            manager.SynchronData = data.Label;
            Console.WriteLine($"Announced Syncronized Data: {manager.SynchronData}");
            //throw new NotImplementedException("FdAmb_SynchronizationPointAnnounced");
            #endregion //User Code
        }
        public override void FdAmb_FederationSynchronized(object sender, HlaFederationManagementEventArgs data)
        {
            base.FdAmb_FederationSynchronized(sender, data);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Federation Synchronized: ({data.Label})" + Environment.NewLine);
        }
        #endregion //Manually Added Code
    }
}