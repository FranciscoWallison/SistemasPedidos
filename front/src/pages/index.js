
import React, { Component } from 'react'
import { Navbar, Nav, Container } from 'react-bootstrap'
import {
    Routes,
    Route,
    Link
} from "react-router-dom";

import Home from './Home';
import Produto from './produto';
import Fornecedor from './fornecedor';
import Pedido from './pedido';

export default class Webpages extends Component {
    render() {
        return (
            <div>
                <div>
                    <Navbar bg="dark" variant="dark">
                        <Container>
                        <Navbar.Brand href="/">SP</Navbar.Brand>
                        <Nav className="me-auto">
                            <Nav.Link as={Link} to="/">Home</Nav.Link>
                            <Nav.Link as={Link} to="/fornecedor">Fornecedores</Nav.Link>
                            <Nav.Link as={Link} to="/pedido">Pedidos</Nav.Link>
                            <Nav.Link as={Link} to="/produto">Produtos</Nav.Link>
                        </Nav>
                        </Container>
                    </Navbar>
                </div>
                <div>
                    <Routes>
                        <Route path="/produto" element={<Pedido />} /> 
                        <Route path="/fornecedor" element={<Fornecedor />} /> 
                        <Route path="/produto" element={<Produto />} /> 
                        <Route path="/" element={<Home />} /> 
                    </Routes>
                </div>
            </div>
        )
    }
}