import React from "react";
import { Nav, NavLink, Bars, NavMenu } from "./NavbarElements";
import CarList from "../../pages/carlist";

const Navbar = () => {
  return (
    <>
      <Nav>
        <Bars />

        <NavMenu>
          <NavLink to="/carlist">
            Car List
          </NavLink>
          {/* <NavLink to="/warehouselist">
            Warehouse List
          </NavLink> */}
          <NavLink to="/shoppingcart">
            Shopping Cart
          </NavLink>
        </NavMenu>
      </Nav>
    </>
  );
};

export default Navbar;
