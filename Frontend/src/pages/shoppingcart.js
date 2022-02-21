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

function ShoppingCart(props) {
  const navigate = useNavigate();
  const { state } = useLocation();

  useEffect(() => {
    // if (state == null) {
    //   navigate("/carlist");
    // }
    // console.log(state.carItem);
  });

  const deleteFromShoppingCart = (carID) => {
    props.actions.deleteShoppingCart(carID);
  };

  const clearShoppingCart = (carID) => {
    props.actions.clearShoppingCart(carID);
    navigate("/carlist");
  };

  const getShoppingTotalPrice = () => {
    let totalPrice = 0;
    for (let carItem of props.shoppingCartState.shoppingCartItems) {
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
          {props.shoppingCartState.shoppingCartItems.map((car) => (
            <div key={car.carID} style={{ marginTop: 20, display: "block" }}>
              <CarItem car={car} />
              <div style={{ position: "right", display: "flex", width: "10%" }}>
                <button onClick={() => deleteFromShoppingCart(car.carID)}>
                  Delete
                </button>
              </div>
            </div>
          ))}
        </div>
        <div style={{ marginTop: 20 }}>
          <b>Total Price : &#8364;{getShoppingTotalPrice()}</b>
        </div>
        <button onClick={() => clearShoppingCart()}>Buy Now !</button>
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
