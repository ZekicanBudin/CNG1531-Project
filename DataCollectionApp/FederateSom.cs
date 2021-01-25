// **************************************************************************************************
//		FederateSom
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
  public class FederateSom : Racon.ObjectModel.CObjectModel
  {
    #region Declarations
    #region SOM Declaration
    public DatasetCollection.Som.CDataCollectionOC DataCollectionOC;
    public DatasetCollection.Som.CMessageIC MessageIC;
    #endregion
    #endregion //Declarations
    
    #region Constructor
    public FederateSom() : base()
    {
      // Construct SOM
      DataCollectionOC = new DatasetCollection.Som.CDataCollectionOC();
      AddToObjectModel(DataCollectionOC);
      MessageIC = new DatasetCollection.Som.CMessageIC();
      AddToObjectModel(MessageIC);
    }
    #endregion //Constructor
  }
}
