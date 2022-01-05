import { Container, Row, Col, Image } from "react-bootstrap";
import { LolGameFullStatsDto } from "../../../../services/GeneratedClient";
import { useHistory } from "react-router";

interface IProps {
    game: LolGameFullStatsDto | null;
    gameType: string;
}

const MatchInfo: React.FunctionComponent<IProps> = (props) => {
    var game = props.game;
    var gameType = props.gameType;

    let history = useHistory();
    const redirectToPage = (page: string) => {
        history.push(page);
    }

    return (
        <Container className="h4 text-white">
            <Row className="align-items-center">
                <Col style={{ textAlign: "right" }}>
                    <Image
                        src={game?.blueTeamStats?.teamImageUrl}
                        className=""
                        width={100}
                        height={100}
                        onClick={() => redirectToPage(`/${gameType}/team/${game?.blueTeamStats?.teamId}`)}
                    />
                </Col>
                <Col style={{ textAlign: "left" }}>
                    {game?.blueTeamStats?.teamName}
                </Col>
                <Col
                    style={{
                        width: "5vh",
                        textAlign: "center",
                    }}
                >
                    <h1>
                        {game?.winnerTeamId == game?.blueTeamStats?.teamId ? 1 : 0}:{game?.winnerTeamId == game?.redTeamStats?.teamId ? 1 : 0}
                    </h1>
                </Col>
                <Col style={{ textAlign: "right" }}>
                    {game?.redTeamStats?.teamName}
                </Col>
                <Col style={{ textAlign: "left" }}>
                    <Image
                        src={game?.redTeamStats?.teamImageUrl}
                        className=""
                        width={100}
                        height={100}
                        onClick={() => redirectToPage(`/${gameType}/team/${game?.redTeamStats?.teamId}`)}
                    />
                </Col>
            </Row>
            <Row>
                <Col style={{ textAlign: "center" }}>
                    {game?.gameLength}
                </Col>
            </Row>
            <Row>
                <Col style={{ textAlign: "center" }}>
                    {game?.startTime?.format("HH:mm DD-MM-YYYY")}
                </Col>
            </Row>
        </Container>
    );
}

export default MatchInfo;