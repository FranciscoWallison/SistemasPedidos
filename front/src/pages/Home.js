import React from 'react'
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';
import fornecedor from '../assets/icon/fornecedor.png';
import pedido from '../assets/icon/pedido.png';
import produtos from '../assets/icon/produtos.png';

const Home = () => {
return(
    <div id="home">
        <Container>
            <Row>
                <Col>
                    <Card style={{ width: '18rem' }}>
                        <Card.Img variant="top" src={fornecedor} />
                        <Card.Body>
                            <Card.Title>Fornecedores</Card.Title>
                            <Card.Text>
                                Informações, Cadastro e Listagem
                            </Card.Text>
                            <Button variant="primary" href="fornecedor">Listagem</Button>
                        </Card.Body>
                    </Card>
                </Col>
                <Col>
                    <Card style={{ width: '18rem' }}>
                        <Card.Img variant="top" src={produtos} />
                        <Card.Body>
                            <Card.Title>Produtos</Card.Title>
                            <Card.Text>
                                Informações, Cadastro e Listagem
                            </Card.Text>
                            <Button variant="primary" href="produto">Listagem</Button>
                        </Card.Body>
                    </Card>
                </Col>
                <Col>
                    <Card style={{ width: '18rem' }}>
                        <Card.Img variant="top" src={pedido} />
                        <Card.Body>
                            <Card.Title>Pedidos</Card.Title>
                            <Card.Text>
                                Informações, Cadastro e Listagem
                            </Card.Text>
                            <Button variant="primary" href="pedido">Listagem</Button>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
        </Container>
    </div>
);
}
export default Home;