import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Form, FormGroup, Label, Input} from "reactstrap";
import { addVehicle } from "../modules/vehicleManager";



//in the return statement, create a form that will add a vehicle
//when the user clicks submit, it calls the onSubmit and posts to the api


export default function VehicleAdd() {
  const navigate = useNavigate();

  const [VehicleYear, setVehicleYear] = useState();
  const [VehicleMake, setVehicleMake] = useState();
  const [VehicleModel, setVehicleModel] = useState();
  const [BodyStyleId, setBodyStyleId] = useState();
  const [VehicleMiles, setVehicleMiles] = useState();
  const [VehicleCost, setVehicleCost] = useState();


  const registerClick = (e) => {
    e.preventDefault();

        const newVehicle = {
        VehicleYear,
        VehicleMake,
        VehicleModel,
        BodyStyleId,
        UserVehicles : {VehicleMiles,
        VehicleCost}
        
      };
      console.log(newVehicle)
      if(newVehicle.bodyStyleId === null){alert("Please select a valid body style.")}else{
      addVehicle(newVehicle).then(() => navigate("/MyVehiclesList"));};
  }
  return (
    <Form onSubmit={registerClick}><div><h4><b>Add A Vehicle...</b></h4></div>
      <fieldset>
        <FormGroup>
          <Label htmlFor="VehicleYear"><b>Vehicle Year</b>  </Label>
          <Input
            id="VehicleYear"
            type="text"
            onChange={(e) => setVehicleYear(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="VehicleMake"><b>Vehicle Make</b>  </Label>
          <Input
            id="VehicleMake"
            type="text"
            onChange={(e) => setVehicleMake(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="VehicleModel"><b>Vehicle Model</b>  </Label>
          <Input
            id="VehicleModel"
            type="text"
            onChange={(e) => setVehicleModel(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label for="BodyStyle"><b>Body Style</b></Label>
          <p></p>
          <select name="BodyStyle"
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
          <Label htmlFor="VehicleMiles"><b>Vehicle Miles</b>  </Label>
          <Input
            id="VehicleMiles"
            type="text"
            onChange={(e) => setVehicleMiles(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label htmlFor="VehicleCost"><b>Vehicle Cost</b>  </Label>
          <Input
            id="VehicleCost"
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