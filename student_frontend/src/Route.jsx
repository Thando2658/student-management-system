import App from "./App.jsx";
import Home from "./Home.jsx";
import LandingPage from "./LandingPage.jsx";
import SignInSignUp from "./SignInSignUp.jsx";
import StudentProfile from './StudentProfile.jsx';
import AdminPage from './AdminPage.jsx';
import ParentProfile from './ParentProfile.jsx';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';


function Newrouter() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<LandingPage />}/>
        <Route path="home" element={<Home />} />
        <Route path="signinsignup" element={<SignInSignUp />} />
        <Route path="adminpage" element={<AdminPage />} />
        <Route path="parentprofile" element={<ParentProfile />} />
        <Route path="studentprofile" element={<StudentProfile />} />
      </Routes>
    </Router>
  );
}

export default Newrouter;