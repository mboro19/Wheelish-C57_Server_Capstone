import React, { useState } from 'react';
import { NavLink as RRNavLink } from "react-router-dom";
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink
} from 'reactstrap';
import { logout } from '../modules/authManager';

export default function Header({ isLoggedIn }) {
  const [isOpen, setIsOpen] = useState(false);
  const toggle = () => setIsOpen(!isOpen);

  return (
    <div>
      <Navbar color="light" light expand="md">
        <NavbarBrand tag={RRNavLink} to="/"><img height={100} src="https://res.cloudinary.com/mboro19/image/upload/v1667366475/wheelish_logo_cvfrid.jpg" alt="Wheelish Logo" /></NavbarBrand>
        <NavbarToggler onClick={toggle} />
        <Collapse isOpen={isOpen} navbar>
          <Nav className="mr-auto" navbar>
            { /* When isLoggedIn === true, we will render the Home link */}
            {isLoggedIn &&
            <>
              <NavItem>
                <NavLink tag={RRNavLink} to="/AllVehicles">
                  All Vehicles
                </NavLink>
              </NavItem>
            </>
            }
          </Nav>
          <Nav navbar>
            {isLoggedIn &&
              <NavItem>
                <NavLink tag={RRNavLink} to="/MyVehiclesList">My Vehicles</NavLink>
              </NavItem>}
          </Nav>
          <Nav navbar>
            {isLoggedIn &&
              <NavItem>
                <NavLink tag={RRNavLink} to="/VehicleAdd">Add Vehicle</NavLink>
              </NavItem>}
          </Nav>
          <Nav navbar>
            {isLoggedIn &&
              <>
              
                <NavItem>
                  <a aria-current="page" className="nav-link"
                    style={{ cursor: "pointer" }} onClick={logout}>Logout</a>
                </NavItem>

              </>
            }
            {!isLoggedIn &&
              <>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/login">Login</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/register">Register</NavLink>
                </NavItem>
              </>
            }
          </Nav>
        </Collapse>
      </Navbar>
    </div>
  );
}
