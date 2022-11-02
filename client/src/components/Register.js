import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { useNavigate, Link } from "react-router-dom";

import { register } from "../modules/authManager";

export default function Register() {
  const navigate = useNavigate();

  const [userName, setUserName] = useState();
  const [userAddress, setUserAddress] = useState();
  const [userCity, setUserCity] = useState();
  const [userState, setUserState] = useState();
  const [userZip, setUserZip] = useState();
  const [userPhone, setUserPhone] = useState();
  const [userEmail, setEmail] = useState();
  const [password, setPassword] = useState();
  const [confirmPassword, setConfirmPassword] = useState();

  const registerClick = (e) => {
    e.preventDefault();
    if (password && password !== confirmPassword) {
      alert("Passwords don't match. Please try again.");
    } else {
      const userProfile = {
        userName,
        userAddress,
        userCity,
        userState,
        userZip,
        userPhone,
        userEmail,
        
      };
      register(userProfile, password).then(() => navigate("/"));

    }
  };

  return (
    <Form onSubmit={registerClick}>
      <fieldset>
        <FormGroup>
          <Label htmlFor="userName">Dealership Name</Label>
          <Input
            id="userName"
            type="text"
            onChange={(e) => setUserName(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="userAddress">Address</Label>
          <Input
            id="userAddress"
            type="text"
            onChange={(e) => setUserAddress(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="userCity">City</Label>
          <Input
            id="userCity"
            type="text"
            onChange={(e) => setUserCity(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label for="userState">State</Label>
          <Input
            id="userState"
            type="text"
            onChange={(e) => setUserState(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="userZip">Zip Code</Label>
          <Input
            id="userZip"
            type="text"
            onChange={(e) => setUserZip(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="userPhone">Phone Number</Label>
          <Input
            id="userPhone"
            type="text"
            onChange={(e) => setUserPhone(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="userEmail">Email</Label>
          <Input
            id="userEmail"
            type="text"
            onChange={(e) => setEmail(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label for="password">Password</Label>
          <Input
            id="password"
            type="password"
            onChange={(e) => setPassword(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label for="confirmPassword">Confirm Password</Label>
          <Input
            id="confirmPassword"
            type="password"
            onChange={(e) => setConfirmPassword(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Button>Register</Button>
        </FormGroup>
      </fieldset>
    </Form>
  );
}
