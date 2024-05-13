import { Link } from 'react-router-dom';


const NavBar = () => {
    return (
        <nav className="navbar">
            <ul className="nav-list">
            <li className="nav-item">
                    <Link to="/" className="nav-link">Main</Link>
                </li>
                <li className="nav-item">
                    <Link to="/home" className="nav-link">Home</Link>
                </li>
                <li className="nav-item">
                    <Link to="/signinsignup" className="nav-link">Access Account</Link>
                </li>
            </ul>
        </nav>
    );
};

export default NavBar;
