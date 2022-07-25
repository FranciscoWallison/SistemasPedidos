import React, { useState, useEffect } from 'react';
import { Button } from 'react-bootstrap';
import Table from 'react-bootstrap/Table';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

const User = () => {
    const [error, setError] = useState(null);
    const [isLoaded, setIsLoaded] = useState(false);
    const [produto, setProduto] = useState([]);
    const [user, setUser] = useState([]);
    const [userAddress, setUserAddress] = useState([]);
    const [userCompany, setUserCompany] = useState([]);
    
    useEffect(() => {
        fetch("http://localhost:8080/api/Produto")
            .then(res => res.json())
            .then(
                (data) => {
                    console.log(data);
                    // let element = "<tbody>";
                    // data.forEach(pedidos => {
                    //   element += `{
                    //     <tr>
                    //       <td>${pedidos.id}</td>
                    //       <td>${pedidos.descricao}</td>
                    //       <td>${pedidos.preco}</td>                          
                    //       <td>${pedidos.dataCadastro}</td>
                    //     </tr>

                    //   }`
                    // });
                    // element += "</tbody>";
                    // setIsLoaded(true);
                    setProduto(data);
                    // setUserAddress(data.address);
                    // setUserCompany(data.company);
                },
                (error) => {
                    setIsLoaded(true);
                    setError(error);
                }
            )
    }, [])
    
    // if (error) {
    //     return <div>Error: {error.message}</div>;
    // }
    // if (!isLoaded) {
    //     return <div>Loading...</div>;
    // }  
    
    // if (user) {
    //     return (
    //         <div>
    //             <h1>{user.name}</h1>
    //             <div>
    //                 Email: {user.email}
    //             </div>
    //             <div>
    //                 Phone: {user.phone}
    //             </div>
    //             <div>
    //                 Website: {user.website}
    //             </div>  
    //             <div>
    //                 Company: {userCompany.name}
    //             </div> 
    //             <div>
    //                 Address: {userAddress.street}, {userAddress.suite}, {userAddress.city}, {userAddress.zipcode}   
    //             </div>
    //       </div>
    //     );
    // }

return(
  <Container>
    {/* add pedido */}
    <Table striped bordered hover>
      <thead>
        <tr>
          <th>#</th>
          <th>Descrição</th>
          <th>Preço</th>
          <th>Data de Cadastro</th>
          {/* editar e adicionar */}
        </tr>
      </thead>
    
      <tbody>
        {produto.map(data => (
          <tr key={data.id}>
              <td>
                {data.id}      
              </td>
              <td>
                {data.descricao}
              </td>
              <td>
                {data.preco}
              </td>
              <td>
                {data.dataCadastro}
              </td>
          </tr>
        ))}        
      </tbody>
    </Table>
  </Container>
);
}
export default User;