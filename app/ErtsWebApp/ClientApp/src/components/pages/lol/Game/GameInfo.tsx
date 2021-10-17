import { Container, Row, Col } from "react-bootstrap";
import { LolGameFullStatsDto } from "../../../../services/GeneratedClient";

function MatchInfo(props: { game: LolGameFullStatsDto | null }) {
    var game = props.game;
    return (
        <Container>
            <Row className="align-items-center">
                <Col style={{ textAlign: "right" }}>
                    <img
                        src={game?.blueTeamStats?.teamImageUrl}
                        className=""
                        width={100}
                        height={100}
                    />
                </Col>
                <Col style={{ textAlign: "left" }}>
                    <div className="h4 text-white">{game?.blueTeamStats?.teamName}</div>
                </Col>
                <Col
                    style={{
                        width: "5vh",
                        textAlign: "center",
                    }}
                >
                    <div className="h1 text-white">
                        {game?.winnerTeamId == game?.blueTeamStats?.teamId ? 1 : 0}:{game?.winnerTeamId == game?.redTeamStats?.teamId ? 1 : 0}
                    </div>
                </Col>
                <Col style={{ textAlign: "right" }}>
                    <div className="h4 text-white">{game?.redTeamStats?.teamName}</div>
                </Col>
                <Col style={{ textAlign: "left" }}>
                    <img
                        src={game?.redTeamStats?.teamImageUrl}
                        className=""
                        width={100}
                        height={100}
                    />
                </Col>
            </Row>
            <Row>
                <Col style={{ textAlign: "center" }}>
                    <div className="h4 text-white">
                        {game?.gameLength}
                    </div>
                </Col>
            </Row>
            <Row>
                <Col style={{ textAlign: "center" }}>
                    <div className="h4 text-white">
                        {game?.startTime?.format("HH:mm DD-MM-YYYY")}
                    </div>
                </Col>
            </Row>
        </Container>
    );
}

export default MatchInfo;