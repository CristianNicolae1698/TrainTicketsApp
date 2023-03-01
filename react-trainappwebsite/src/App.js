import React, { Fragment, useState } from 'react';
import NavBar from "./components/NavBar";
import {BrowserRouter as Router, Route, Routes} from 'react-router-dom'
import './App.css';
import Home from './components/Pages/Home';
import SignUpComponent from './components/SignUpComponent';
import store from "./components/redux/store"
import { Provider } from 'react-redux'

function App() {
  const [token, setToken]=useState('');
  return (
    <>
    <Router>
    <Fragment>
    <NavBar />
      <Routes>
        
        
      
          <Route index element={<Home/>}/>
          <Route path='/SignUp' element={<SignUpComponent/>}/>
      
      </Routes>
      </Fragment>
    </Router>
    </>
  );
}

export default App;
