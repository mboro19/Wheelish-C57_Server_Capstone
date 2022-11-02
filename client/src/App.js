
import './App.css';
import { onLoginStatusChange } from './modules/authManager.js';
import React, {useEffect, useState} from 'react';
import {BrowserRouter as Router} from "react-router-dom";
import {Spinner} from 'reactstrap';
import Header from "./components/Header.js";
import { ApplicationViews } from './components/ApplicationViews.js';


function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(null);

  useEffect(()=>{
    onLoginStatusChange(setIsLoggedIn)
  },[]);
  
  if(isLoggedIn === null){
    return <Spinner className="app-spinner dark" />;
  }

  return (
    <Router>
      <Header isLoggedIn={isLoggedIn} />
      <ApplicationViews isLoggedIn={isLoggedIn} />
    </Router>
  );
}

export default App;
