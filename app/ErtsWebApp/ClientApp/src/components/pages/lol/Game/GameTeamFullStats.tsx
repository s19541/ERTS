import { Container, Row, Col, Image } from "react-bootstrap";
import { LolGameTeamFullStatsDto } from "../../../../services/GeneratedClient";
import GameTeamExcludingStats from "./GameTeamExcludingStats";
import { useTranslation } from "react-i18next";

interface IProps {
    blueTeamStats: LolGameTeamFullStatsDto | undefined;
    redTeamStats: LolGameTeamFullStatsDto | undefined;
}

const GameTeamFullStats: React.FunctionComponent<IProps> = (props) => {
    const blueTeamStats = props.blueTeamStats;
    const redTeamStats = props.redTeamStats;
    const { t } = useTranslation();

    return (
        <Container style={{ color: "white" }}>
            <Row>
                <Col style={{ textAlign: "right" }}><h4>{blueTeamStats?.goldEarned}</h4></Col>
                <Col style={{ textAlign: "center" }}><h4>{t("game.info.gold")}</h4></Col>
                <Col style={{ textAlign: "left" }}><h4>{redTeamStats?.goldEarned}</h4></Col>
            </Row>
            <Row>
                <Col style={{ textAlign: "right" }}><h4>{blueTeamStats?.kills}</h4></Col>
                <Col style={{ textAlign: "center" }}><h4>{t("game.info.kills")}</h4></Col>
                <Col style={{ textAlign: "left" }}><h4>{redTeamStats?.kills}</h4></Col>
            </Row>
            <Row>
                <Col style={{ textAlign: "right" }}>
                    <h4>
                        <Image
                            src={blueTeamStats?.ban1ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                        <Image
                            src={blueTeamStats?.ban2ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                        <Image
                            src={blueTeamStats?.ban3ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                        <Image
                            src={blueTeamStats?.ban4ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                        <Image
                            src={blueTeamStats?.ban5ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                    </h4>
                </Col>
                <Col style={{ textAlign: "center" }}><h4>{t("game.info.bans")}</h4></Col>
                <Col style={{ textAlign: "left" }}>
                    <h4>
                        <Image
                            src={redTeamStats?.ban1ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                        <Image
                            src={redTeamStats?.ban2ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                        <Image
                            src={redTeamStats?.ban3ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                        <Image
                            src={redTeamStats?.ban4ImageUrl}
                            className=""
                            width={29}
                            height={29}
                        />
                        <Image
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
                        {[...Array(blueTeamStats?.oceanDrakeKilled)].map((x, i) => (
                            <Image
                                src="/images/lol/ocean-drake-icon.png"
                                width={29}
                                height={29}
                                alt="oceanDrake"
                            />
                        ))}
                        {[...Array(blueTeamStats?.infernalDrakeKilled)].map((x, i) => (
                            <Image
                                src="/images/lol/infernal-drake-icon.png"
                                width={29}
                                height={29}
                                alt="infernalDrake"
                            />
                        ))}
                        {[...Array(blueTeamStats?.mountainDrakeKilled)].map((x, i) => (
                            <Image
                                src="/images/lol/mountain-drake-icon.png"
                                width={29}
                                height={29}
                                alt="mountainDrake"
                            />
                        ))}
                        {[...Array(blueTeamStats?.cloudDrakeKilled)].map((x, i) => (
                            <Image
                                src="/images/lol/cloud-drake-icon.png"
                                width={29}
                                height={29}
                                alt="cloudDrake"
                            />
                        ))}
                        {redTeamStats != null ? redTeamStats.infernalDrakeKilled + redTeamStats.oceanDrakeKilled + redTeamStats.mountainDrakeKilled + redTeamStats.cloudDrakeKilled : 0}
                    </h4>
                </Col>
                <Col style={{ textAlign: "center" }}><h4>{t("game.info.dragons")}</h4></Col>
                <Col style={{ textAlign: "left" }}>
                    <h4>
                        {redTeamStats != null ? redTeamStats.infernalDrakeKilled + redTeamStats.oceanDrakeKilled + redTeamStats.mountainDrakeKilled + redTeamStats.cloudDrakeKilled : 0}
                        {[...Array(redTeamStats?.oceanDrakeKilled)].map((x, i) => (
                            <Image
                                src="/images/lol/ocean-drake-icon.png"
                                width={29}
                                height={29}
                                alt="oceanDrake"
                            />
                        ))}
                        {[...Array(redTeamStats?.infernalDrakeKilled)].map((x, i) => (
                            <Image
                                src="/images/lol/infernal-drake-icon.png"
                                width={29}
                                height={29}
                                alt="infernalDrake"
                            />
                        ))}
                        {[...Array(redTeamStats?.mountainDrakeKilled)].map((x, i) => (
                            <Image
                                src="/images/lol/mountain-drake-icon.png"
                                width={29}
                                height={29}
                                alt="mountainDrake"
                            />
                        ))}
                        {[...Array(redTeamStats?.cloudDrakeKilled)].map((x, i) => (
                            <Image
                                src="/images/lol/cloud-drake-icon.png"
                                width={29}
                                height={29}
                                alt="cloudDrake"
                            />
                        ))}
                    </h4>
                </Col>
            </Row>
            <Row>
                <Col style={{ textAlign: "right" }}><h4>{blueTeamStats?.elderDrakeKilled}</h4></Col>
                <Col style={{ textAlign: "center" }}><h4>{t("game.info.elders")}</h4></Col>
                <Col style={{ textAlign: "left" }}><h4>{redTeamStats?.elderDrakeKilled}</h4></Col>
            </Row>
            <Row>
                <Col style={{ textAlign: "right" }}><h4>{blueTeamStats?.baronKilled}</h4></Col>
                <Col style={{ textAlign: "center" }}><h4>{t("game.info.barons")}</h4></Col>
                <Col style={{ textAlign: "left" }}><h4>{redTeamStats?.baronKilled}</h4></Col>
            </Row>
            <Row >
                <Col style={{ textAlign: "right" }}><h4>{blueTeamStats?.heraldKilled}</h4></Col>
                <Col style={{ textAlign: "center" }}><h4>{t("game.info.heralds")}</h4></Col>
                <Col style={{ textAlign: "left" }}><h4>{redTeamStats?.heraldKilled}</h4></Col>
            </Row>
            <Row>
                <Col style={{ textAlign: "right" }}><h4>{blueTeamStats?.turretDestroyed}</h4></Col>
                <Col style={{ textAlign: "center" }}><h4>{t("game.info.turrets")}</h4></Col>
                <Col style={{ textAlign: "left" }}><h4>{redTeamStats?.turretDestroyed}</h4></Col>
            </Row>
            <Row>
                <Col style={{ textAlign: "right" }}><h4>{blueTeamStats?.inhibitorDestroyed}</h4></Col>
                <Col style={{ textAlign: "center" }}><h4>{t("game.info.inhibitors")}</h4></Col>
                <Col style={{ textAlign: "left" }}><h4>{redTeamStats?.inhibitorDestroyed}</h4></Col>
            </Row>
            <GameTeamExcludingStats name={t("game.info.first-blood")} blueTeamBoolean={blueTeamStats?.firstBlood} redTeamBoolean={redTeamStats?.firstBlood} />
            <GameTeamExcludingStats name={t("game.info.first-dragon")} blueTeamBoolean={blueTeamStats?.firstDragon} redTeamBoolean={redTeamStats?.firstDragon} />
            <GameTeamExcludingStats name={t("game.info.first-baron")} blueTeamBoolean={blueTeamStats?.firstBaron} redTeamBoolean={redTeamStats?.firstBaron} />
            <GameTeamExcludingStats name={t("game.info.first-turret")} blueTeamBoolean={blueTeamStats?.firstTurret} redTeamBoolean={redTeamStats?.firstTurret} />
            <GameTeamExcludingStats name={t("game.info.first-inhibitor")} blueTeamBoolean={blueTeamStats?.firstInhibitor} redTeamBoolean={redTeamStats?.firstInhibitor} />
        </Container>
    );
}

export default GameTeamFullStats;