import { Container, Row, Col, AccordionCollapse, AccordionToggle } from "react-bootstrap";
import Accordion from 'react-bootstrap/Accordion'
import { isGetAccessorDeclaration } from "typescript";
import { LolGamePlayerFullStatsDto } from "../../../../services/GeneratedClient";

function GamePlayerFullStatsItem(props: { playerStats: LolGamePlayerFullStatsDto | undefined }) {
    const playerStats = props.playerStats;

    return (
        <Container style={{ color: "white" }}>
            <Row>
                <Col>
                    <img
                        src={playerStats?.championImageUrl}
                        className=""
                        width={100}
                        height={100}
                    />
                </Col>
            </Row>
            <Row>
                <Col>
                    <h4>{playerStats?.playerNick}</h4>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h4>KDA: {playerStats?.kills}/{playerStats?.deaths}/{playerStats?.assists}</h4>
                </Col>
            </Row>
            <Accordion defaultActiveKey="0">
                <Accordion.Collapse eventKey="0">

                    <h3>xd</h3>
                </Accordion.Collapse>
                <Accordion.Collapse eventKey="1">
                    <h3>xd</h3>
                </Accordion.Collapse>
                <Row>
                    <Col>
                        <h5>GOLD EARNED: {playerStats?.goldEarned}</h5>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <h5>GOLD SPENT: {playerStats?.goldSpent}</h5>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <h4>DAMAGE DEALT: {playerStats?.damageDealt}</h4>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <h6>MAGIC DAMAGE DEALT: {playerStats?.magicDamageDealt}</h6>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <h6>PHYSICAL DAMAGE DEALT: {playerStats?.physicalDamageDealt}</h6>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <h6>TRUE DAMAGE DEALT: {playerStats?.trueDamageDealt}</h6>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <h4>DAMAGE DEALT TO CHAMPIONS: {playerStats?.damageDealtToChamps}</h4>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <h6>MAGIC DAMAGE DEALT TO CHAMPIONS: {playerStats?.magicDamageDealtToChamps}</h6>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <h6>PHYSICAL DAMAGE DEALT TO CHAMPIONS: {playerStats?.physicalDamageDealtToChamps}</h6>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <h6>TRUE DAMAGE DEALT TO CHAMPS: {playerStats?.trueDamageDealtToChamps}</h6>
                    </Col>
                </Row>
            </Accordion>
        </Container>
    );
}

export default GamePlayerFullStatsItem;