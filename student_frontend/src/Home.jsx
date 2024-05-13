import React from 'react';
import App from './App';


function Home() {
  return (
    <div>
        <App/>
      <main className="container">
        <h1>Welcome to Student Management System</h1>
        <p className="intro-text">This website was created to provide our Staff, Students and Parents with...</p>
        
       
        <div className="card">
          <h4>Students</h4>
            <ol>
            <li>Students can manage their personal information </li>
            <li>Register and login using their user names and passwords</li>
            <li>Students can upload their profile picture</li>
            <li>Students can view their Grades</li>
            </ol>

        </div>
        <div className="card">
        <h4>Parents</h4>
            <ol>
            <li>Parents can manage their personal information </li>
            <li>Register and login using their user names and passwords</li>
            <li>Add their contact details</li>
            <li>Add Residential Address</li>
            </ol>
        </div>
        <div className="card">
        <h4>Staff</h4>
            <ol>
            <li>Staff can manage students information </li>
            <li>Register and login using their user names and passwords</li>
            <li>Upload and download student information</li>
            <li>Manage the portal</li>
            </ol>
        </div>
      
      </main>
      {/* ... other sections */}
    </div>
  );
}

export default Home;
