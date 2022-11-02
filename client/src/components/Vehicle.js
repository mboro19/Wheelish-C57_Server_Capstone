import React from "react";
import { Card, CardBody } from "reactstrap";

export const Vehicles = ({ vehicle }) => {
  return (
    <Card >
      <CardBody>
        <p><b>Year:</b> {vehicle.vehicleYear}</p>
        <p><b>Make:</b> {vehicle.vehicleMake}</p>
        <p><b>Model:</b> {vehicle.vehicleModel}</p>
        <p><b>Miles:</b> {vehicle.userVehicles.vehicleMiles}</p>
        <p><b>Cost:</b> ${vehicle.userVehicles.vehicleCost}</p>
        
      </CardBody>
    </Card>
  );
};

