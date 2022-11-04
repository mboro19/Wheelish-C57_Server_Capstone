import React from "react";
import { Card, CardBody} from "reactstrap";
import {Link} from 'react-router-dom';


export const VehicleDealerDetails = (user) => {


    return (
        <Card >
          <CardBody>
            <p><b>Dealership:</b> {user.userName}</p>
            <p><b>Address:</b> {user.userAddress}</p>
            <p><b>City:</b> {user.userCity}</p>
            <p><b>State:</b> {user.userState}</p>
            <p><b>Phone:</b> {user.userPhone}</p>
            <p><b>Email:</b> {user.userEmail}</p>    
          </CardBody>
        </Card>
      );
}