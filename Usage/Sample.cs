/* Sample.cs : This Unity3D script is attached to a gameObject and illustrates how statemachines can be called and executed.
    Copyright (C) 2011 Deepthy Menon

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using UnityEngine;
using System.Collections;

public class Sample : MonoBehaviour{
	
	
  SampleStateMachine sampleStateMachine;
	
  protected EventPublisherListener pubInstance;
  protected bool somethingOccurs = false;
  
  void Start () {
		
		InitEventTriggers ();
    sampleStateMachine = ScriptableObject.CreateInstance<SampleStateMachine>( );
	  sampleStateMachine.Enable (   ); 
 }
 
 void Update(){	
		
		
		if ( sampleStateMachine != null ) {
			
			sampleStateMachine.Update (); // Executes the state machine delegate function as applicable.
	
		}
    /* Do something .... */
    if ( somethingOccurs ) {
       pubInstance.NotifyListeners ("ChangeState");
       somethingOccurs = false;
    }
	
	}
 
 void OnDestroy () {
		
    sampleStateMachine.Disable ();
		Destroy ( sampleStateMachine );
		
	}
 
 
 void InitEventTriggers ( bool register = true ) {
		
     // In this sample, you are not receiving any events, you are just notifying listeners.
      // So register/unRegister functions are not required. In case it is, add the functions along
      // the same lines as InitEventTriggers function as shown in SampleStateMachine.cs
		
		
		if ( register ) {
			
			if ( pubInstance == null ) {
				
				pubInstance = EventPublisherListener.Instance;
				// AddRegister functions if applicable
				
			}
     
		}
		else if ( pubInstance != null ) {
			
      //Add Unregister functions if applicable
			
		}
	
	}
 
}
 
 
