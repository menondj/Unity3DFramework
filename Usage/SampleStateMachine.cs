/* SampleStateMachine.cs : Example of how a StateMachine can be created for a game
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

public class SampleStateMachine : StateMachine {


	
 // Use this for initialization
public UserStateMachine (  ) {
   
   InitEventTriggers ( ); // Register for Events which cause the StateChanges
   ProcessStateMachine += WaitState; // A  State when the scriptable object is instantiated	
}
	
  
  public void Enable () {
   // Initialise StateMachines, pass parameters if applicable
  }
  
  public void Disable () {
  
    Cleanup();
  }
	
  
  override protected void Cleanup () {
	// Do your own cleanup
	base.Cleanup ();
   }
	
	
	
  // Update is called once per frame this is made virtual, since waitstate is common 
 virtual protected void WaitState () {
		/* Do something here */
 }
		
 virtual protected void NewState () {
	
		/* Do something here */
		
		
}

  void InitEventTriggers ( bool register = true ) {
		
		
		if ( register ) {
			
			if ( pubInstance == null ) { 
			
				pubInstance = EventPublisherListener.Instance;
				if ( pubInstance == null ) {
					
					Debug.LogError ( " Unable to load EventPublisherListener" );
					
				}
				
			}
			pubInstance.Register ( "ChangeState", this.ChangeState );
			pubInstance.Register ( "GoBackToWait", this.GoBackToWait );
			
		}
		else {
			
			if ( pubInstance != null ) {
				
        		  pubInstance.UnRegister ( "ChangeState", this.ChangeState );
			  pubInstance.UnRegister ( "GoBackToWait", this.GoBackToWait );

				
			}
			
		}
		
	}
  
  void ChangeState ( params GameObject[] dummy ) {
      ProcessStateMachine -= WaitState;
      ProcessStateMachine += NewState;
  }
  
  void GoBackToWait ( params GameObject[] dummy ) {
      ProcessStateMachine -= NewState;
      ProcessStateMachine += WaitState;
  }
  
		
}

