import { Col, Container, Form, Nav, Navbar, NavDropdown } from "react-bootstrap";
import { useHistory } from "react-router";
import React, { useState } from 'react';

function GameNav(props: { activeKey: string, gameType: string, onHandleEvent: any }) {
    let history = useHistory();
    const [leagues, setLeagues] = useState(0);
    const redirectToPage = (page: string) => {
        history.push(page);
    }

    const key = props.activeKey;
    const gameType = props.gameType;
    const onHandleEvent = props.onHandleEvent;

    return (

        <Navbar variant="dark" bg="dark">
            <Container fluid>

                <Navbar.Brand style={{ width: 800 }}>
                    <Form>
                        <Col md="auto">
                            <Form.Control type="text" placeholder="Enter fragment of league name" onChange={(event) => onHandleEvent(event.target.value)} />
                        </Col>
                    </Form>
                </Navbar.Brand>
                <Navbar.Brand>
                    <Nav activeKey={"Leagues"}>
                        <NavDropdown
                            id="nav-dropdown"
                            title={key}
                        >
                            <NavDropdown.Item eventKey="Leagues" default >Leagues</NavDropdown.Item>
                            <NavDropdown.Item eventKey="Teams">Teams</NavDropdown.Item>
                        </NavDropdown>
                    </Nav>
                </Navbar.Brand>
            </Container>
        </Navbar>
    );
}

export default GameNav;