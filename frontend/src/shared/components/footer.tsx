import React, { FunctionComponent, useMemo } from "react";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";

const Footer: FunctionComponent = () => {
  const year = useMemo<number>(() => new Date().getFullYear(), []);

  return (
    <footer className="p-3">
      <Navbar fixed="bottom" bg="light">
        <Nav className="mr-auto">© {year}</Nav>
      </Navbar>
    </footer>
  );
};

export default Footer;
