import React, { useState, useEffect } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import CarItem from "../components/CarItem";
//redux
import { connect, useStore } from "react-redux";
import { bindActionCreators } from "redux";
import {
  addShoppingCart,
  deleteShoppingCart,
  clearShoppingCart,
} from "../redux/actions/shoppingCartActions";
import axios from "axios";
import {
  USER_ID,
  SHOPPING_BASE_URL,
  GET_ALL_SHOPPING_CART,
  DELETE_CAR_FROM_SHOPPING_CART,
  COMPLETE_SHOPPING_CART,
  HEADER_CONFIG,
  CAR_LIST
} from "../constants/constants";

function ShoppingCart(props) {
  const navigate = useNavigate();
  const [shoppingItems, setshoppingItems] = useState([]);

  useEffect(() => {
    axios.get(SHOPPING_BASE_URL + GET_ALL_SHOPPING_CART).then((response) => {
      setshoppingItems(response.data.slice());
    });
  },[]);

  const deleteFromShoppingCart = (carID) => {
    axios
      .post(
        SHOPPING_BASE_URL + DELETE_CAR_FROM_SHOPPING_CART,
        carID,
        HEADER_CONFIG
      )
      .then((response) => {
        axios
          .get(SHOPPING_BASE_URL + GET_ALL_SHOPPING_CART)
          .then((response) => {
            setshoppingItems(response.data.slice());
          });
      });
  };

  const buyShoppingCart = (userID) => {
    axios
      .post(SHOPPING_BASE_URL + COMPLETE_SHOPPING_CART, userID, HEADER_CONFIG)
      .then((response) => {
        navigate(CAR_LIST);
      });
  };

  const getShoppingTotalPrice = () => {
    let totalPrice = 0;
    for (let carItem of shoppingItems) {
      totalPrice += carItem.price;
    }
    return totalPrice;
  };

  return (
    <>
      <div
        style={{
          width: "80%",
          marginLeft: "5%",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <h1>Shopping Cart</h1>
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
          {shoppingItems.map((car) => (
            <div key={car.id} style={{ marginTop: 20, display: "block" }}>
              <CarItem car={car} />
              <div style={{ position: "right", display: "flex", width: "10%" }}>
                <button onClick={() => deleteFromShoppingCart(car.id)}>
                  Delete
                </button>
              </div>
            </div>
          ))}
        </div>
        <div style={{ marginTop: 20 }}>
          <b>Total Price : &#8364;{getShoppingTotalPrice()}</b>
        </div>
        <button onClick={() => buyShoppingCart(USER_ID)}>Buy Now !</button>
      </div>
    </>
  );
}

const mapStateToProps = (state) => {
  return {
    shoppingCartState: state.shoppingCartState,
  };
};

const ActionCreators = Object.assign(
  {},
  { addShoppingCart, deleteShoppingCart, clearShoppingCart }
);
const mapDispatchToProps = (dispatch) => {
  return { actions: bindActionCreators(ActionCreators, dispatch) };
};

export default connect(mapStateToProps, mapDispatchToProps)(ShoppingCart);
