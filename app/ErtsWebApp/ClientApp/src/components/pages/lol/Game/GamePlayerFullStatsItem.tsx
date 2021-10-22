import { Container, Row, Col, AccordionCollapse, AccordionToggle } from "react-bootstrap";
import { LolGamePlayerFullStatsDto } from "../../../../services/GeneratedClient";

function GamePlayerFullStatsItem(props: { playerStats: LolGamePlayerFullStatsDto | undefined }) {
    const playerStats = props.playerStats;

    return (
        <Container style={{ color: "white" }}>
            <Row>
                <Col>
                    <h4><img src={`/images/lol/role${playerStats?.role}.png`} className="" width={50} height={50} /></h4>
                </Col>
            </Row>
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

                    {playerStats?.itemImages?.map((itemImage, i) => (
                        <img src={itemImage} className="" width={35} height={35} />
                    ))}

                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>LEVEL: {playerStats?.level}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h4>KDA: {playerStats?.kills}/{playerStats?.deaths}/{playerStats?.assists}</h4>
                </Col>
            </Row>
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
            <Row>
                <Col>
                    <h5>TOWERS DESTROYED: {playerStats?.turretsDestroyed}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>INHIBITORS DESTROYED: {playerStats?.inhibitorsDestroyed}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>WARDS PLACED: {playerStats?.wardsPlaced}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>WARDS DESTROYED: {playerStats?.wardsDestroyed}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>TOTAL TIME CROWD CONTROLL DEALT: {playerStats?.totalTimeCrowdControllDealt}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>TOTAL HEAL: {playerStats?.totalHeal}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>MINIONS KILLED: {playerStats?.cs}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>NEUTRAL MINIONS KILLED: {playerStats?.neutralMinionsKilled}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>ENEMY NEUTRAL MINIONS KILLED: {playerStats?.enemyNeutralMinionsKilled}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>LARGEST CRITICAL STRIKE: {playerStats?.largestCriticalStrike}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>LARGEST KILLING SPREE: {playerStats?.largestKillingSpree}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>LARGEST MULTI KILL: {playerStats?.largestMultiKill}</h5>
                </Col>
            </Row>
        </Container>
    );
}

export default GamePlayerFullStatsItem;