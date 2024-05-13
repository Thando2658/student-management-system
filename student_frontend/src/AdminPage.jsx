import React from 'react';
import App from './App.jsx';

const AdminProfile = ({ user }) => {
    return (
        <div>
            <h1>Welcome, {user.First_Name}!</h1>
            <p>Position: Staff</p>
            {/* Add more admin-specific information here */}
        </div>
    );
};

export default AdminProfile;
