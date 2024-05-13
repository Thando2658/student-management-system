import React from 'react';
import App from './App.jsx';

const ParentProfile = ({ user }) => {
    return (
        <div>
            <h1>Welcome, {user.First_Name}!</h1>
            <p>Contact Details: {user.ContactDetails}</p>
            <p>Address: {user.AddressDetails}</p>
            {/* Add more parent-specific information here */}
        </div>
    );
};

export default ParentProfile;
