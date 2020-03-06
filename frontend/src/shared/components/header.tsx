import React, { FunctionComponent } from "react";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import { useHistory } from "react-router-dom";
import NavDropdown from "react-bootstrap/NavDropdown";

const Header: FunctionComponent = () => {
  const { push } = useHistory();

  return (
    <header>
      <Navbar
        collapseOnSelect
        expand="md"
        bg="dark"
        variant="dark"
        fixed="top"
      >
        <Navbar.Brand onClick={() => push("/")}>Customer App</Navbar.Brand>
        <Navbar.Toggle aria-controls="responsive-navbar-nav" />
        <Navbar.Collapse id="responsive-navbar-nav">
          <Nav className="mr-auto">
            <NavDropdown title="Kunden" id="collasible-nav-dropdown">
              <NavDropdown.Item onClick={() => push("/customer/list")}>
                Liste
              </NavDropdown.Item>
              <NavDropdown.Item onClick={() => push("/customer/new")}>
                Hinzufügen
              </NavDropdown.Item>
            </NavDropdown>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    </header>
  );
};

export default Header;
