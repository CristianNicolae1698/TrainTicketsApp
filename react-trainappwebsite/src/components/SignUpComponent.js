import React from 'react'
import { useState } from "react"
import { Button } from './Button';
import App from '../App'
import { useSelector, useDispatch } from "react-redux";
import{updateUser} from "./redux/user.js";

function SignUpComponent() {
  

  const [optionsState, setOptionsState] = useState([])
  const [firstName, setFirstName] = useState('')
  const [lastName, setLastName] = useState('')
  const [token, setToken]=useState('');
  const user=useSelector((state)=>state.user.value)
  const dispatch=useDispatch();
  
  



  var PostClientUrl = new URL('https://localhost:7007/api/client/SignUp');
  var ReturnClientUrl = new URL('https://localhost:7007/api/client/SignIn');

  const handleSubmitSignUp = () => {
    const body = {
        "FirstName": firstName,
        "LastName": lastName
    };
    fetch(PostClientUrl, {
        method: 'POST',
        body: JSON.stringify(body),
        headers: {
            "content-type": "application/json"
        }
    })
        .then(data => data.json())
        .then(response => console.log(response));
        alert("You have been successfully signed up " + lastName);
    
}

const handleSubmitSignIn = () => {
  const body = {
      "FirstName": firstName,
      "LastName": lastName
  };
  fetch(ReturnClientUrl, {
      method: 'POST',
      body: JSON.stringify(body),
      headers: {
          "content-type": "application/json"
      }
  })
      .then(response => response.json())
      .then((responseData) => { setToken(responseData) });
      console.log(token)
      dispatch(updateUser(token));
      alert("You have been successfully signed in for " + user)
      
  
  
  
  

}








  return (
    <><>
    <div className='signup-container'>
        
            
    
             
        <h1>Fill in the blank fields with your credentials</h1>        
        <form class="form" method="dialog">
            <div><label>Your First Name</label><input onChange={(e) => setFirstName(e.target.value)} type="text" /></div>
                <label>Your Last Name </label><input onChange={(e) => setLastName(e.target.value)} type="text" id="lastName" />
        </form>
                
            <Button onClick={()=>handleSubmitSignIn()}>Sign In</Button>
            <Button onClick={() => handleSubmitSignUp()}>Sign Up</Button>
            
           
           
    </div>

    
    </></>

  );
};

export default SignUpComponent