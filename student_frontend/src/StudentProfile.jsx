import React from 'react';
import App from './App.jsx';

const StudentProfile = ({ user }) => {
    return (
        <div>
            <h1>Welcome, {user.First_Name}!</h1>
            <p>Date of Birth: {user.DOB}</p>
            <p>Sex: {user.Sex}</p>
            <p>Grade: {user.Grade}</p>
            <p>Student Number: {user.StudentNumber}</p>
            <img src={user.ProfilePicture} alt="Profile" style={{ maxWidth: '200px', maxHeight: '200px' }} />
            {/* Add more student-specific information here */}
            <p>Username: {user.User.UserName}</p>
            <p>User Type: Student</p>
        </div>
    );
};

export default StudentProfile;
