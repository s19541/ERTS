import { useState } from "react";
import { Col, Container, Form, Nav, Navbar, NavDropdown } from "react-bootstrap";
import { useHistory } from "react-router";
import { useLocation } from "react-router-dom";

const GameNav = (props: { activeKey: string, gameType: string, onHandleEvent: (fragment: string) => void }) => {


    let history = useHistory();

    const useQuery = () => {
        return new URLSearchParams(useLocation().search);
    }

    const [formValue, setFormValue] = useState<string | undefined>(useQuery().get("fragment")?.toString() ?? "");


    let redirectToPage = (page: string) => {
        history.push({
            pathname: page,
            search: '?fragment=' + formValue
        })
    }

    function onHandle(fragment: string) {
        setFormValue(fragment);
        props.onHandleEvent(fragment);
    }

    return (

        <Navbar variant="dark" bg="dark">
            <Container fluid>

                <Navbar.Brand style={{ width: "100%" }}>
                    <Form>
                        <Col md="auto">
                            <Form.Control type="text" defaultValue={formValue} placeholder="Enter fragment of league name" onChange={(event) => onHandle(event.target.value)} />
                        </Col>
                    </Form>
                </Navbar.Brand>
                <Navbar.Brand id="navbar-dark-example">
                    <Nav activeKey={props.activeKey}>
                        <NavDropdown
                            id="nav-dropdown"
                            title={props.activeKey}
                            menuVariant="dark"
                        >
                            <NavDropdown.Item eventKey="Leagues" onClick={() => redirectToPage("./leagues")}>Leagues</NavDropdown.Item>
                            <NavDropdown.Item eventKey="Teams" onClick={() => redirectToPage("./teams")}>Teams</NavDropdown.Item>
                        </NavDropdown>
                    </Nav>
                </Navbar.Brand>
            </Container>
        </Navbar>
    );
}

export default GameNav;