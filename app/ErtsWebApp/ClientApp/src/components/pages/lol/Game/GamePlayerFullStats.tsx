import { Container, Row, Col } from "react-bootstrap";
import { LolGamePlayerFullStatsDto } from "../../../../services/GeneratedClient";
import GamePlayerFullStatsItem from "./GamePlayerFullStatsItem";
import { useTranslation } from "react-i18next";

interface IProps {
    blueTeamPlayersStats: LolGamePlayerFullStatsDto[] | undefined;
    redTeamPlayersStats: LolGamePlayerFullStatsDto[] | undefined;
}

const GamePlayerFullStats: React.FunctionComponent<IProps> = (props) => {
    const blueTeamPlayersStats = props.blueTeamPlayersStats;
    const redTeamPlayersStats = props.redTeamPlayersStats;
    const { t } = useTranslation();

    return (
        <Container style={{ color: "white" }}>
            <Row style={{ textAlign: "center" }}>
                <Col><h1>{t("game.players")}</h1></Col>
            </Row>
            <Row>
                <Col style={{ textAlign: "right" }} >
                    {blueTeamPlayersStats?.map((playerStats, i) => (
                        <GamePlayerFullStatsItem playerStats={playerStats} />
                    ))}
                </Col>
                <Col style={{ textAlign: "left" }} >
                    {redTeamPlayersStats?.map((playerStats, i) => (
                        <GamePlayerFullStatsItem playerStats={playerStats} />
                    ))}
                </Col>
            </Row>
        </Container>
    );
}

export default GamePlayerFullStats;