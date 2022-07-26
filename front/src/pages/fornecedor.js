import React, { useState, useEffect } from 'react';

import Table from 'react-bootstrap/Table';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import Spinner from 'react-bootstrap/Spinner';

const Fornecedor = () => {
    const [loading, setloading] = useState(false);
    const [alerting, setAlerting] = useState(false);
    const [formulario, setFormulario] = useState(true);
    
    
    const [typeSend, setTypeSend] = useState([]);  
    const [title, setTitle] = useState([]);
    const [produto, setProduto] = useState([]);
    const [show, setShow] = useState(false);
    const [showdelete, setShowdelete] = useState(false);

    const [nome, setNome] = useState("");
    const [razaosocial, setRazaosocial] = useState("");
    const [email, setEmail] = useState("");
    const [uf, setUf] = useState("");
    const [cnpj, setCnpj] = useState("");
    

    useEffect(() => {
      getall();
    }, [])

    const fnHandleSubmit = event => {
      event.preventDefault();
      console.log('event', event)
      // iniciar requisição
      setloading(true);
      setFormulario(false);

      let fornecedor = {
        "nome": event.target[0].value,
        "razaoSocial": event.target[1].value,
        "email": event.target[2].value,
        "uf": event.target[3].value,
        "cnpj": event.target[4].value,
        "pedidos": [
        ]
      }

      console.log('event', event, fornecedor)
      submit(fornecedor);
  }

  function getall() {
    fetch("http://localhost:8080/api/Fornecedor")
            .then(res => res.json())
            .then(
                (data) => {
                  console.log(data);
                  setProduto(data);
                },
                (error) => {
                  // setIsLoaded(true);
                  // setError(error);
                }
            ).finally(() => {
             
            })
    }

    function editar(id) {
      setFormulario(true);
      console.log('Fornecedores, editar', id);
      fetch("http://localhost:8080/api/Fornecedor/"+id)
      .then(res => res.json())
      .then(
          (data) => {
              setTitle("Editar Fornecedor");
              
              setNome(data.nome)
              setRazaosocial(data.razaoSocial)
              setEmail(data.email)
              setUf(data.uf)
              setCnpj(data.cnpj)

              setShow(true);

              setTypeSend({type:"update", id: id});
              
          },
          (error) => {
              // setIsLoaded(true);
              // setError(error);
          }
      )
    }

    function deletar(id) {
      console.log('Fornecedores, deletar', id);
      setTypeSend({type:"delete", id: id});

      handleShowDelete();
    }

    function criar() {
      setFormulario(true);
      setShow(true);
      setNome("")
      setRazaosocial("")
      setEmail("")
      setUf("")
      setCnpj("")

      setTitle("Criar Fornecedor");
      setTypeSend({type:"create", id: 0});
      console.log('Fornecedores, Criar');
    }
    
    const createClose = () => setShow(false);
    // const handleShow = () => setShow(true);

    function update(id, fornecedor) {
      const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(fornecedor)
      };
      fetch('http://localhost:8080/api/Fornecedor/'+id, requestOptions)
        .then(response => response.json())
        .then(data => console.log("update - fornecedor") )
        .finally(() => {
          getall()
          setloading(false);
          setAlerting(true);
          setFormulario(false);
        });
    }

    function deleteproduto(id) {
      const requestOptions = {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' }
      };
      fetch('http://localhost:8080/api/Fornecedor/'+id, requestOptions)
        .then(response => response.json())
        .then(data => console.log("update - fornecedor") )
        .finally(() => {
          getall()
          setloading(false);          
          setAlerting(false);
          handleCloseDelete();
        });
    }


    function create(fornecedor) {
      const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(fornecedor)
      };
      fetch('http://localhost:8080/api/Fornecedor/', requestOptions)
        .then(response => response.json())
        .then(data => console.log("update - fornecedor") )
        .finally(() => {
          getall()
          setloading(false);
          setAlerting(true);
          setFormulario(false);
        });
    }

    // function onSubmit(event) {
    //   console.log("onSubmit",event)
    // }

    function submit(fornecedor) {
      switch (typeSend.type) {
        case "create":
          create(fornecedor);
          break;
        case "update":
          update(typeSend.id, fornecedor);
          break;
        case "delete":
          deleteproduto(typeSend.id);
          break;
          
        default:
          break;
      }
    }
    
  const handleCloseDelete = () => setShowdelete(false);
  const handleShowDelete = () => setShowdelete(true);

return(
  <>
    

    <Container>
      <Row xs={2} md={4} lg={6}>
      <Col>
        <h1>
          Fornecedores {' '} <Button variant="success"  onClick={criar} size="lg">Criar</Button>
        </h1>
        </Col>  {' '}
      </Row>
      {' '}
      {/* add fornecedor */}
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>#</th>
            <th>Nome</th>
            <th>Razão Social</th>
            <th>cnpj</th>
            <th>Email</th>
            <th>UF</th>            
            <th>Editar / Deletar</th>
          </tr>
        </thead>
      
        <tbody>
          {produto.map(data => (
            <tr key={data.id}>
                <td>
                  {data.id}
                </td>
                <td>
                  {data.nome}
                </td>
                <td>
                  {data.razaoSocial}
                </td>
                <td>
                  {data.cnpj}
                </td>
                <td>
                  {data.email}
                </td>
                <td>
                  {data.uf}
                </td>
                <th>
                  <Button variant="primary" onClick={(e) =>editar(data.id)} size="lg">Editar</Button>
                  {' '}
                  <Button variant="danger" onClick={(e) =>deletar(data.id)} size="lg">Deletar</Button>
                </th>
            </tr>
          ))}        
        </tbody>
      </Table>
      {/* MODAL */}
      <Modal show={show} onHide={createClose} animation={false} fade={false}>

        <Modal.Header closeButton>
          <Modal.Title>{title}</Modal.Title>
        </Modal.Header>
        <Spinner animation="border" role="status" style={{display: loading ? 'block' : 'none' }}>
          <span className="visually-hidden">Loading...</span>
        </Spinner>
        <Container style={{display: alerting ? 'block' : 'none' }}>
          <div >
            Cadastrado com Sucesso!
            <hr />
            <div className="d-flex justify-content-end">
              <Button onClick={createClose} variant="outline-success">
                Ok
              </Button>
            </div>
          </div>
        </Container>
        <Container style={{display: formulario ? 'block' : 'none' }}>
          <form onSubmit={fnHandleSubmit}>

            <Form.Group className="mb-3" controlId="formBasicNome">
              <Form.Label>Nome</Form.Label>
              <Form.Control name="nome" type="text" placeholder="Enter nome" defaultValue={nome} />
              <Form.Text className="text-muted">
               Nome do Fornecedor
              </Form.Text>
            </Form.Group>


            <Form.Group className="mb-3" controlId="formBasicrazaoSocial">
              <Form.Label>Razão Social</Form.Label>
              <Form.Control name="razaosocial" type="text" placeholder="Enter razaosocial" defaultValue={razaosocial} />
              <Form.Text className="text-muted">
               Razão Social do Fornecedor
              </Form.Text>
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicEmail">
              <Form.Label>Email</Form.Label>
              <Form.Control name="email" type="email" placeholder="Enter email" defaultValue={email} />
              <Form.Text className="text-muted">
               Email do Fornecedor
              </Form.Text>
            </Form.Group>


            <Form.Select >
              <option>UF</option>
              <option value="CE">CE</option>
              <option value="SP">SP</option>
              <option value="BA">BA</option>
            </Form.Select>

            <Form.Group className="mb-3" controlId="formBasicCNPJ">
              <Form.Label>CNPJ</Form.Label>
              <Form.Control name="cnpj" type="cnpj" placeholder="Enter cnpj" defaultValue={cnpj} />
              <Form.Text className="text-muted">
               CNPJ do Fornecedor
              </Form.Text>
            </Form.Group>
            
            <Modal.Footer>
              <Button variant="secondary" onClick={createClose}>
                Fechar
              </Button>
              
              <Button variant="primary" type="submit" >
                Salvar
              </Button>
            </Modal.Footer>
          </form>
        </Container>
      </Modal>
      {/* Delete */}

      <Modal show={showdelete} onHide={handleCloseDelete} animation={false} fade={false}>
        <Modal.Header closeButton>
          <Modal.Title>Tem certeza que deseja deletar o Fornecedor</Modal.Title>
        </Modal.Header>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleCloseDelete}>
            Cancelar
          </Button>
          <Button variant="danger" onClick={submit} >
            Deletar
          </Button>
        </Modal.Footer>
      </Modal>

    </Container>
  </>
);
}
export default Fornecedor;