import { Container, Row, Col } from "react-bootstrap";
import { LolGamePlayerFullStatsDto } from "../../../../services/GeneratedClient";
import GamePlayerFullStatsItem from "./GamePlayerFullStatsItem";

function GamePlayerFullStats(props: { blueTeamPlayersStats: LolGamePlayerFullStatsDto[] | undefined, redTeamPlayersStats: LolGamePlayerFullStatsDto[] | undefined }) {
    const blueTeamPlayersStats = props.blueTeamPlayersStats;
    const redTeamPlayersStats = props.redTeamPlayersStats;

    return (
        <Container style={{ color: "white" }}>
            <Row style={{ textAlign: "center" }}>
                <Col><h1>PLAYERS</h1></Col>
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