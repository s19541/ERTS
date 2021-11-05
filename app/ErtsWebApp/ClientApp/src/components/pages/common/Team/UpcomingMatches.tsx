import { Container, Row, Col, Table, Image } from "react-bootstrap";
import { TeamUpcomingMatchDto } from "../../../../services/GeneratedClient";

import { useHistory } from "react-router";

function LastMatches(props: {
    upcomingMatches: TeamUpcomingMatchDto[] | undefined;
}) {
    let history = useHistory();
    const redirectToPage = (page: string) => {
        history.push(page);
    }

    var upcomingMatches = props.upcomingMatches;
    return (
        <Container style={{ textAlign: "right" }}>
            <h1>Upcoming Matches</h1>
            {upcomingMatches?.map((match, i) => (
                <Row onClick={() => redirectToPage(`/lol/match/${match.matchId}`)} >
                    <Col md="auto">
                        <Image src={match.leagueImageUrl}
                            width={25}
                            height={25} />
                        {match?.startTime?.format("HH:mm DD-MM-YYYY")}
                    </Col>
                    <Col md="auto">
                        <Image src={match.team1ImageUrl}
                            width={25}
                            height={25} />
                        {match.team1Name} vs {match.team2Name}
                        <Image src={match.team2ImageUrl}
                            width={25}
                            height={25} />
                    </Col>

                </Row>
            ))}
        </Container>
    );
}

export default LastMatches;