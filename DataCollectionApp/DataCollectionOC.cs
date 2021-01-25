// **************************************************************************************************
//		CDataCollectionOC
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
/// This class is extended from the object model of RACoN API
/// </summary>

// System
using System;
using System.Collections.Generic; // for List
// Racon
using Racon;
using Racon.RtiLayer;
// Application
using DatasetCollection.Som;


namespace DatasetCollection.Som
{
  public class CDataCollectionOC : HlaObjectClass
  {
    #region Declarations
    public HlaAttribute DataCollectionData;
    #endregion //Declarations
    
    #region Constructor
    public CDataCollectionOC() : base()
    {
      // Initialize Class Properties
      Name = "HLAobjectRoot.DataCollection";
      ClassPS = PSKind.PublishSubscribe;
      
      // Create Attributes
      // DataCollectionData
      DataCollectionData = new HlaAttribute("DataCollectionData", PSKind.PublishSubscribe);
      Attributes.Add(DataCollectionData);
    }
    #endregion //Constructor
  }
}
