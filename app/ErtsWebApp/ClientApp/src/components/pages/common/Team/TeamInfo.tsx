import { Container, Row, Col, Image } from "react-bootstrap";
import { TeamDto } from "../../../../services/GeneratedClient";

interface IProps {
    team: TeamDto | null;
}
const TeamInfo: React.FunctionComponent<IProps> = (props) => {
    var team = props.team;
    return (
        <Container>
            <Row className="align-items-center">
                <Col md="auto">
                    <Image src={team?.imageUrl}
                        width={250}
                        height={250} />
                </Col>
                <Col md="auto">
                    <h1>{team?.name}</h1>
                    <h3>{team?.acronym}</h3>
                </Col>

            </Row>
        </Container>
    );
}

export default TeamInfo;