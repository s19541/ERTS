import { Container, Row, Col, Image } from "react-bootstrap";
import { TeamPastMatchDto } from "../../../../services/GeneratedClient";
import { useHistory } from "react-router";
import { useTranslation } from "react-i18next";

interface IProps {
    lastMatches: TeamPastMatchDto[] | undefined;
}
const LastMatches: React.FunctionComponent<IProps> = (props) => {
    let history = useHistory();
    const { t } = useTranslation();
    const redirectToPage = (page: string) => {
        history.push(page);
    }

    var lastMatches = props.lastMatches;
    return (
        <Container>
            <h1>{t("team.last-matches")}</h1>
            {lastMatches?.map((match, i) => (
                <Row onClick={() => redirectToPage(`/lol/match/${match.matchId}`)}>
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
                        {match.team1Name} {match.team1GamesWon}:{match.team2GamesWon} {match.team2Name}
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