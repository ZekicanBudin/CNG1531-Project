// **************************************************************************************************
//		CHumanHlaObject
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
/// This is a wrapper class for local data structures. This class is extended from the object model of RACoN API
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
  public class CHumanHlaObject : HlaObject
  {
    #region Declarations
    // TODO: Declare your local object structure here
    // Your_LocalData_Type Data;
    #endregion //Declarations
    
    #region Constructor
    public CHumanHlaObject(HlaObjectClass _type) : base(_type)
    {
      // TODO: Instantiate local data here
      // var Data = new Your_LocalData_Type();
    }
    // Copy constructor - used in callbacks
    public CHumanHlaObject(HlaObject _obj) : base(_obj)
    {
      // TODO: Instantiate local data here
      // var Data = new Your_LocalData_Type();
    }
    #endregion //Constructor
  }
}
