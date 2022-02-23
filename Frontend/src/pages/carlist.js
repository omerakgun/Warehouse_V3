import React from "react";
import axios from "axios";
import CarItem from "../components/CarItem";
import {
  WAREHOUSE_BASE_URL,
  GET_ALL_CAR,
} from "../constants/constants";

class CarList extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      cars: [],
    };
  }

  componentDidMount() {
    axios.get(WAREHOUSE_BASE_URL+GET_ALL_CAR).then((response) => {
      this.setState({ cars: response.data });
    });
  }

  render() {
    return (
      <>
        <div style={{ width: "90%", marginLeft: "5%" }}>
          <h1>Hello from Car List</h1>
          <div
            style={{
              display: "flex",
            }}
          >
            <div style={{ width: "10%" }}>
              <b>Make</b>
            </div>
            <div style={{ width: "10%" }}>
              <b>Model</b>
            </div>
            <div style={{ width: "10%" }}>
              <b>Year Model</b>
            </div>
            <div style={{ width: "10%" }}>
              <b>Price</b>
            </div>
            <div style={{ width: "10%" }}>
              <b>Location</b>
            </div>
            <div style={{ width: "10%" }}>
              <b>Licensed</b>
            </div>
            <div style={{ width: "10%" }}>
              <b>Date Added</b>
            </div>
            <div style={{ width: "10%" }}>
              <b>Detail</b>
            </div>
          </div>
          <div style={{ marginTop: 7 }}>
            {this.state.cars.map((car) => (
              <div key={car.carID}>
                <CarItem car={car} />
              </div>
            ))}
          </div>
        </div>
      </>
    );
  }
}

export default CarList;
