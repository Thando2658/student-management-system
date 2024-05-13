import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import NavBar from './NavBar.jsx';
import App from './App.jsx';


const LandingPage = () => {
    return (
      <div className="landing-page">
        <App />
        <div className="container">
          <h1>Welcome to Student Management System</h1>
          <p className="intro-text">Your one-stop solution for managing students.</p>
          <img src="/src/images/student_portal.png" alt="Image" />
        </div>
        {/* Footer or additional sections */}
      </div>
    );
  };
  
  export default LandingPage;