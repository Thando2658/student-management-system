import { useState } from 'react';
import Modal from 'react-modal';
import App from './App';
import StudentProfile from './StudentProfile';
import AdminProfile from './AdminPage';
import ParentProfile from './ParentProfile';


const SignInSignUp = () => {
    const [firstName, setFirstname] = useState('');
    const [lastName, setLastname] = useState('');
    const [userType, setUsertype] = useState('');
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [newUsername, setNewUsername] = useState('');
    const [newPassword, setNewPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');
    const [signUpMessage, setSignUpMessage] = useState('');
    const [showSignUp, setShowSignUp] = useState(false);
    const [showModal, setShowModal] = useState(false);
    const [loggedInUser, setLoggedInUser] = useState(null);

    const handleSignIn = async () => {
        try {
            // Your sign-in logic here
            const userData = await fetchUserData(username, password); // Fetch user data
            setLoggedInUser(userData); // Store logged-in user data
            setShowModal(true); // Show modal for successful sign-in
        } catch (error) {
            setErrorMessage(`Sign In Error: ${error.message}`);
        }
    };
    const fetchUserData = async (username, password) => {
        // Mock function to fetch user data from backend
        const response = await fetch(`/api/User?password=${password}&username=${username}`);
        if (!response.ok) {
            // If the response is not OK, throw an error with the status text
            throw new Error(`Error: ${response.status} ${response.statusText}`);
        }
        const data = await response.json();
        if (!data) {
            throw new Error('No data received');
        }
        return data;
    };

    const handleSignUp = async () => {
        try {
            let userData = {
                firstName,
                lastName,
                username: newUsername,
                password: newPassword,
                userType: parseInt(userType),
            };

            // Prepare additional data based on user type
            switch (userType) {
                case '0': // Parent
                    userData = {
                        ...userData,
                        // Add parent-specific data here
                    };
                    break;
                case '1': // Student
                    userData = {
                        ...userData,
                        // Add student-specific data here
                        grade: 'GradeValue',
                        studentNumber: 'StudentNumberValue',
                        profilePicture: 'ProfilePictureBase64String',
                    };
                    break;
                case '2': // Admin
                    userData = {
                        ...userData,
                        // Add admin-specific data here
                        uploadCSV: 'CSVFileBase64String',
                    };
                    break;
                default:
                    throw new Error('Invalid user type');
            }

            const response = await fetch('/api/User/AddUser', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(userData),
            });

            if (!response.ok) {
                throw new Error('Error signing up');
            }

            setSignUpMessage('Sign Up successful!');
            setShowModal(true);
        } catch (error) {
            setErrorMessage(error.message);
        }
    };
    const closeModal = () => {
        setShowModal(false);
    };

    return (
        <div>
            <App />
            {!loggedInUser ? (
                <div className='container'>
                    <h2>Login</h2>
                    <input type="text" placeholder="Username" value={username} onChange={(e) => setUsername(e.target.value)} />
                    <input type="password" placeholder="Password" value={password} onChange={(e) => setPassword(e.target.value)} />
                    <button onClick={handleSignIn}>Sign In</button>
                    {errorMessage && <p>{errorMessage}</p>}
                    <p>Dont have an account? <button onClick={() => setShowSignUp(true)}>Sign Up</button></p>
                </div>
            ) : (
                <div>
                    {loggedInUser.userType === 1 && <StudentProfile user={loggedInUser} />}
                    {loggedInUser.userType === 2 && <AdminProfile user={loggedInUser} />}
                    {loggedInUser.userType === 0 && <ParentProfile user={loggedInUser} />}
                </div>
            )}
            <Modal isOpen={showModal} onRequestClose={closeModal}>
                <h2>Registration Successful</h2>
                <p>Your registration was successful.</p>
                <button onClick={closeModal}>Close</button>
            </Modal>
        </div>
 )};


export default SignInSignUp;
