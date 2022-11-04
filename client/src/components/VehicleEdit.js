import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Form, FormGroup } from "reactstrap";
import { editVehicle, getVehicleById } from "../modules/vehicleManager";

export const VehicleEdit = () => {
  const { vehicleId } = useParams();

  const [updatedVehicle, setUpdatedVehicle] = useState({
    id: vehicleId,
    vehicleYear: null,
    vehicleMake: "",
    vehicleModel: "",
    bodyStyleId: null,
    userVehicles: {
      vehicleMiles: null,
      vehicleCost: null,
    },
  });
  const navigate = useNavigate();

  const getVehicles = () => {
    getVehicleById(vehicleId).then((vehicle) => {
      setUpdatedVehicle({ ...vehicle });
    });
  };

  useEffect(() => {
    getVehicles(vehicleId);
  }, []);

  useEffect(() => {});

  const handleEditButtonClick = (vehicle) => {
    editVehicle(vehicle).then(navigate("/MyVehiclesList"));
  };

  return (
    <>
      <Form>
        <FormGroup>
          <fieldset>
            <div>
              <div>
              <label className="label_input" htmlFor="VehicleYear"><b>New Vehicle Year:</b></label>
              <input
                className="form-control"
                value={updatedVehicle.vehicleYear}
                type="VehicleYear"
                placeholder="Enter Vehicle Year..."
                onChange={(evt) => {
                  let copy = { ...updatedVehicle };
                  copy.vehicleYear = evt.target.value;
                  setUpdatedVehicle(copy);
                }}
              />
              </div>
              <div>
              <label className="label_input" htmlFor="VehicleMake"><b>Vehicle Make:</b></label>
              <input
                className="form-control"              
                value={updatedVehicle.vehicleMake}
                type="VehicleMake"
                placeholder="Enter Vehicle Make..."
                onChange={(evt) => {
                  let copy = { ...updatedVehicle };
                  copy.vehicleMake = evt.target.value;
                  setUpdatedVehicle(copy);
                }}
              />
              </div>
              <div>
              <label className="label_input" htmlFor="VehicleModel"><b>Vehicle Model:</b></label>
              <input
                className="form-control"
                value={updatedVehicle.vehicleModel}
                type="VehicleModel"
                placeholder="Enter Vehicle Model..."
                onChange={(evt) => {
                  let copy = { ...updatedVehicle };
                  copy.vehicleModel = evt.target.value;
                  setUpdatedVehicle(copy);
                }}
              />
              </div>
              <div>
              <label className="label_input" htmlFor="BodyStyleId"><b>Body Style</b></label>
              
              <select className="form-control"
                name="BodyStyleId"
                value={updatedVehicle.bodyStyleId}
                onChange={(evt) => {
                  let copy = { ...updatedVehicle };
                  copy.bodyStyleId = evt.target.value;
                  setUpdatedVehicle(copy);
                }}
              >
                <option value={null}>Select One</option>
                <option value={1}>Car</option>
                <option value={2}>Truck</option>
                <option value={3}>SUV</option>
                <option value={4}>Van</option>
                <option value={5}>Other</option>
              </select>
              </div>
              <div>
              <label className="label_input" htmlFor="VehicleMiles"><b>Vehicle Miles:</b></label>
              <input
                className="form-control"              
                value={updatedVehicle.userVehicles.vehicleMiles}
                type="VehicleMiles"
                placeholder="Enter Vehicle Miles..."
                onChange={(evt) => {
                  let copy = { ...updatedVehicle };
                  copy.userVehicles.vehicleMiles = evt.target.value;
                  setUpdatedVehicle(copy);
                }}
              />
              </div>
              <div>
              <label className="label_input" htmlFor="VehicleCost"><b>Vehicle Cost:</b></label>
              <input
                className="form-control"              
                value={updatedVehicle.userVehicles.vehicleCost}
                type="VehicleCost"
                placeholder="Enter Vehicle Cost..."
                onChange={(evt) => {
                  let copy = { ...updatedVehicle };
                  copy.userVehicles.vehicleCost = evt.target.value;
                  setUpdatedVehicle(copy);
                }}
              />
              </div>
              
              <button
                onClick={(e) => {
                  e.preventDefault();
                  handleEditButtonClick(updatedVehicle);
                }}
              >
                Save
              </button>
              <button
                onClick={() => {
                  navigate("/MyVehiclesList");
                }}
              >
                Cancel
              </button>
            </div>
          </fieldset>
        </FormGroup>
      </Form>
    </>
  );
};
