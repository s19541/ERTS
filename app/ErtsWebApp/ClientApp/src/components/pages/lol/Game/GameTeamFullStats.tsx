import { Container, Row, Col } from "react-bootstrap";
import { LolGameTeamFullStatsDto } from "../../../../services/GeneratedClient";
import GameTeamExcludingStats from "./GameTeamExcludingStats";

function GameTeamFullStats(props: { blueTeamStats: LolGameTeamFullStatsDto | undefined, redTeamStats: LolGameTeamFullStatsDto | undefined }) {
    const blueTeamStats = props.blueTeamStats;
    const redTeamStats = props.redTeamStats;

    return (
        <Container style={{ color: "white" }}>
            <Row>
                <Col style={{ textAlign: "right" }}><h4>{blueTeamStats?.goldEarned}</h4></Col>
                <Col style={{ textAlign: "center" }}><h4>GOLD</h4></Col>
                <Col style={{ textAlign: "left" }}><h4>{redTeamStats?.goldEarned}</h4></Col>
            </Row>
            <Row>
                <Col style={{ textAlign: "right" }}><h4>{blueTeamStats?.kills}</h4></Col>
                <Col style={{ textAlign: "center" }}><h4>KILLS</h4></Col>
                <Col style={{ textAlign: "left" }}><h4>{redTeamStats?.kills}</h4></Col>
            </Row>
            <Row>
                <Col style={{ textAlign: "right" }}>
                    <h4>
                        <img
                            src={blueTeamStats?.ban1ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                        <img
                            src={blueTeamStats?.ban2ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                        <img
                            src={blueTeamStats?.ban3ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                        <img
                            src={blueTeamStats?.ban4ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                        <img
                            src={blueTeamStats?.ban5ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                    </h4>
                </Col>
                <Col style={{ textAlign: "center" }}><h4>BANS</h4></Col>
                <Col style={{ textAlign: "left" }}>
                    <h4>
                        <img
                            src={redTeamStats?.ban1ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                        <img
                            src={redTeamStats?.ban2ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                        <img
                            src={redTeamStats?.ban3ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                        <img
                            src={redTeamStats?.ban4ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                        <img
                            src={redTeamStats?.ban5ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                    </h4>
                </Col>
            </Row>
            <Row >
                <Col style={{ textAlign: "right" }}>
                    <h4>
                        ({[...Array(blueTeamStats?.oceanDrakeKilled)].map((x, i) => (
                            <img
                                src="/images/lol/ocean-drake-icon.png"
                                width={29}
                                height={29}
                                alt="oceanDrake"
                            />
                        ))}
                        {[...Array(blueTeamStats?.infernalDrakeKilled)].map((x, i) => (
                            <img
                                src="/images/lol/infernal-drake-icon.png"
                                width={29}
                                height={29}
                                alt="infernalDrake"
                            />
                        ))}
                        {[...Array(blueTeamStats?.mountainDrakeKilled)].map((x, i) => (
                            <img
                                src="/images/lol/mountain-drake-icon.png"
                                width={29}
                                height={29}
                                alt="mountainDrake"
                            />
                        ))}
                        {[...Array(blueTeamStats?.cloudDrakeKilled)].map((x, i) => (
                            <img
                                src="/images/lol/cloud-drake-icon.png"
                                width={29}
                                height={29}
                                alt="cloudDrake"
                            />
                        ))})
                        {redTeamStats != null ? redTeamStats.infernalDrakeKilled + redTeamStats.oceanDrakeKilled + redTeamStats.mountainDrakeKilled + redTeamStats.cloudDrakeKilled : 0}
                    </h4>
                </Col>
                <Col style={{ textAlign: "center" }}><h4>DRAKES</h4></Col>
                <Col style={{ textAlign: "left" }}>
                    <h4>
                        {redTeamStats != null ? redTeamStats.infernalDrakeKilled + redTeamStats.oceanDrakeKilled + redTeamStats.mountainDrakeKilled + redTeamStats.cloudDrakeKilled : 0}
                        ({[...Array(redTeamStats?.oceanDrakeKilled)].map((x, i) => (
                            <img
                                src="/images/lol/ocean-drake-icon.png"
                                width={29}
                                height={29}
                                alt="oceanDrake"
                            />
                        ))}
                        {[...Array(redTeamStats?.infernalDrakeKilled)].map((x, i) => (
                            <img
                                src="/images/lol/infernal-drake-icon.png"
                                width={29}
                                height={29}
                                alt="infernalDrake"
                            />
                        ))}
                        {[...Array(redTeamStats?.mountainDrakeKilled)].map((x, i) => (
                            <img
                                src="/images/lol/mountain-drake-icon.png"
                                width={29}
                                height={29}
                                alt="mountainDrake"
                            />
                        ))}
                        {[...Array(redTeamStats?.cloudDrakeKilled)].map((x, i) => (
                            <img
                                src="/images/lol/cloud-drake-icon.png"
                                width={29}
                                height={29}
                                alt="cloudDrake"
                            />
                        ))})
                    </h4>
                </Col>
            </Row>
            <Row>
                <Col style={{ textAlign: "right" }}><h4>{blueTeamStats?.elderDrakeKilled}</h4></Col>
                <Col style={{ textAlign: "center" }}><h4>ELDERS</h4></Col>
                <Col style={{ textAlign: "left" }}><h4>{redTeamStats?.elderDrakeKilled}</h4></Col>
            </Row>
            <Row>
                <Col style={{ textAlign: "right" }}><h4>{blueTeamStats?.baronKilled}</h4></Col>
                <Col style={{ textAlign: "center" }}><h4>BARONS</h4></Col>
                <Col style={{ textAlign: "left" }}><h4>{redTeamStats?.baronKilled}</h4></Col>
            </Row>
            <Row >
                <Col style={{ textAlign: "right" }}><h4>{blueTeamStats?.heraldKilled}</h4></Col>
                <Col style={{ textAlign: "center" }}><h4>HERALDS</h4></Col>
                <Col style={{ textAlign: "left" }}><h4>{redTeamStats?.heraldKilled}</h4></Col>
            </Row>
            <Row>
                <Col style={{ textAlign: "right" }}><h4>{blueTeamStats?.turretDestroyed}</h4></Col>
                <Col style={{ textAlign: "center" }}><h4>TURRETS</h4></Col>
                <Col style={{ textAlign: "left" }}><h4>{redTeamStats?.turretDestroyed}</h4></Col>
            </Row>
            <Row>
                <Col style={{ textAlign: "right" }}><h4>{blueTeamStats?.inhibitorDestroyed}</h4></Col>
                <Col style={{ textAlign: "center" }}><h4>INHIBITORS</h4></Col>
                <Col style={{ textAlign: "left" }}><h4>{redTeamStats?.inhibitorDestroyed}</h4></Col>
            </Row>
            <GameTeamExcludingStats name="FIRST BLOOD" blueTeamBoolean={blueTeamStats?.firstBlood} redTeamBoolean={redTeamStats?.firstBlood} />
            <GameTeamExcludingStats name="FIRST DRAGON" blueTeamBoolean={blueTeamStats?.firstDragon} redTeamBoolean={redTeamStats?.firstDragon} />
            <GameTeamExcludingStats name="FIRST BARON" blueTeamBoolean={blueTeamStats?.firstBaron} redTeamBoolean={redTeamStats?.firstBaron} />
            <GameTeamExcludingStats name="FIRST TURRET" blueTeamBoolean={blueTeamStats?.firstTurret} redTeamBoolean={redTeamStats?.firstTurret} />
            <GameTeamExcludingStats name="FIRST INHIBITOR" blueTeamBoolean={blueTeamStats?.firstInhibitor} redTeamBoolean={redTeamStats?.firstInhibitor} />
        </Container>
    );
}

export default GameTeamFullStats;