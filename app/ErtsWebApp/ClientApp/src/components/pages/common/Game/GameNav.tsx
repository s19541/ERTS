import { useState } from "react";
import { Col, Container, Form, Nav, Navbar, NavDropdown } from "react-bootstrap";
import { useHistory } from "react-router";
import { useLocation } from "react-router-dom";
import { useTranslation } from "react-i18next";

const GameNav = (props: { activeKey: string, gameType: string, onHandleEvent: (fragment: string) => void }) => {


    let history = useHistory();
    const { t } = useTranslation();

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
                            <Form.Control type="text" defaultValue={formValue} placeholder={t("game-type.nav.placeholder")} onChange={(event) => onHandle(event.target.value)} />
                        </Col>
                    </Form>
                </Navbar.Brand>
                <Navbar.Brand id="navbar-dark-example">
                    <Nav activeKey={props.activeKey}>
                        <NavDropdown
                            id="nav-dropdown"
                            title={t(`game-type.nav.${props.activeKey}`)}
                            menuVariant="dark"
                        >
                            <NavDropdown.Item eventKey="leagues" onClick={() => redirectToPage("./leagues")}>{t("game-type.nav.leagues")}</NavDropdown.Item>
                            <NavDropdown.Item eventKey="teams" onClick={() => redirectToPage("./teams")}>{t("game-type.nav.teams")}</NavDropdown.Item>
                        </NavDropdown>
                    </Nav>
                </Navbar.Brand>
            </Container>
        </Navbar>
    );
}

export default GameNav;