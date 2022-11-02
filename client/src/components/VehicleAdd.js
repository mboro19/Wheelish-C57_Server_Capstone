import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Form, FormGroup, Label, Input, UncontrolledDropdown, DropdownToggle, DropdownMenu, DropdownItem } from "reactstrap";
import { addVehicle } from "../modules/vehicleManager";
import { DropdownProps } from "reactstrap";



//in the return statement, create a form that will add a vehicle
//when the user clicks submit, it calls the onSubmit and posts to the api


export default function VehicleAdd() {
  const navigate = useNavigate();

  const [vehicleYear, setVehicleYear] = useState();
  const [vehicleMake, setVehicleMake] = useState();
  const [vehicleModel, setVehicleModel] = useState();
  const [bodyStyleId, setBodyStyleId] = useState();
  const [vehicleMiles, setVehicleMiles] = useState();
  const [vehicleCost, setVehicleCost] = useState();


  const registerClick = (e) => {
    e.preventDefault();

        const newVehicle = {
        vehicleYear,
        vehicleMake,
        vehicleModel,
        bodyStyleId,
        vehicleMiles,
        vehicleCost
        
      };
      console.log(newVehicle)
      if(newVehicle.bodyStyleId === null){alert("Please select a valid body style.")}else{
      addVehicle(newVehicle).then(() => navigate("/MyVehicleList"));};
  }
  return (
    <Form onSubmit={registerClick}><div><h4><b>Add A Vehicle...</b></h4></div>
      <fieldset>
        <FormGroup>
          <Label htmlFor="vehicleYear"><b>Vehicle Year</b>  </Label>
          <Input
            id="vehicleYear"
            type="text"
            onChange={(e) => setVehicleYear(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="vehicleMake"><b>Vehicle Make</b>  </Label>
          <Input
            id="vehicleMake"
            type="text"
            onChange={(e) => setVehicleMake(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="vehicleModel"><b>Vehicle Model</b>  </Label>
          <Input
            id="vehicleModel"
            type="text"
            onChange={(e) => setVehicleModel(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label for="bodyStyle"><b>Body Style</b></Label>
          <p></p>
          <select name="bodyStyle"
            onChange={(e) => setBodyStyleId(e.target.value)}>
            <option value={null}>Select One</option>
            <option value={1}>Car</option>
            <option value={2}>Truck</option>
            <option value={3}>SUV</option>
            <option value={4}>Van</option>
            <option value={5}>Other</option>
          </select>
          
        </FormGroup>
        <FormGroup>
          <Label htmlFor="vehicleMiles"><b>Vehicle Miles</b>  </Label>
          <Input
            id="vehicleMiles"
            type="text"
            onChange={(e) => setVehicleMiles(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="vehicleCost"><b>Vehicle Cost</b>  </Label>
          <Input
            id="vehicleCost"
            type="text"
            onChange={(e) => setVehicleCost(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Button>Submit</Button>
        </FormGroup>
      </fieldset>
    </Form>
  );
}