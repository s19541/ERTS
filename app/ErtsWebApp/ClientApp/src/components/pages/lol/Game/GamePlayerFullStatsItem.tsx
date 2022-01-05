import { Container, Row, Col, Accordion } from "react-bootstrap";
import { LolGamePlayerFullStatsDto } from "../../../../services/GeneratedClient";
import { useTranslation } from "react-i18next";

interface IProps {
    playerStats: LolGamePlayerFullStatsDto | undefined;
}

const GamePlayerFullStatsItem: React.FunctionComponent<IProps> = (props) => {
    const playerStats = props.playerStats;
    const { t } = useTranslation();

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
                    <h5>{t("game.player.level")}: {playerStats?.level}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h4>{t("game.player.kills")}: {playerStats?.kills}/{playerStats?.deaths}/{playerStats?.assists}</h4>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>{t("game.player.gold-earned")}: {playerStats?.goldEarned}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>{t("game.player.gold-spent")}: {playerStats?.goldSpent}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h4>{t("game.player.damage-dealt")}: {playerStats?.damageDealt}</h4>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h6>{t("game.player.magic-damage-dealt")}: {playerStats?.magicDamageDealt}</h6>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h6>{t("game.player.physical-damage-dealt")}: {playerStats?.physicalDamageDealt}</h6>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h6>{t("game.player.true-damage-dealt")}: {playerStats?.trueDamageDealt}</h6>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h4>{t("game.player.damage-dealt-to-champions")}: {playerStats?.damageDealtToChamps}</h4>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h6>{t("game.player.magic-damage-dealt-to-champions")}: {playerStats?.magicDamageDealtToChamps}</h6>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h6>{t("game.player.physical-damage-dealt-to-champions")}: {playerStats?.physicalDamageDealtToChamps}</h6>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h6>{t("game.player.true-damage-dealt-to-champions")}: {playerStats?.trueDamageDealtToChamps}</h6>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>{t("game.player.towers-destroyed")}: {playerStats?.turretsDestroyed}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>{t("game.player.inhibitors-destroyed")}: {playerStats?.inhibitorsDestroyed}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>{t("game.player.wards-placed")}: {playerStats?.wardsPlaced}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>{t("game.player.wards-destroyed")}: {playerStats?.wardsDestroyed}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>{t("game.player.total-time-crowd-control-dealt")}: {playerStats?.totalTimeCrowdControllDealt}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>{t("game.player.total-heal")}: {playerStats?.totalHeal}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>{t("game.player.minions-killed")}: {playerStats?.cs}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>{t("game.player.neutral-minions-killed")}: {playerStats?.neutralMinionsKilled}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>{t("game.player.enemy-neutral-minions-killed")}: {playerStats?.enemyNeutralMinionsKilled}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>{t("game.player.largest-critical-strike")}: {playerStats?.largestCriticalStrike}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>{t("game.player.largest-killing-spree")}: {playerStats?.largestKillingSpree}</h5>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h5>{t("game.player.largest-multikill")}: {playerStats?.largestMultiKill}</h5>
                </Col>
            </Row>
        </Container>
    );
}

export default GamePlayerFullStatsItem;