import React from "react";
import { Container, Col, Row, Image } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";
import "../../../../css/myStyle.css";
import { TeamClient, TeamDto } from "../../../../services/GeneratedClient";
import {
    IActionParameters,
    SendActionWithResponse,
} from "../../../../_infrastructure/actions/SendAction";

interface IProps { }

interface IPassedProps {
    teamId: string;
}

interface IState {
    teamId: number;
    team: TeamDto | null;
}

type IJoinedProps = IProps & RouteComponentProps<IPassedProps>;

class TeamStats extends React.Component<IJoinedProps, IState> {
    constructor(props: IJoinedProps) {
        super(props);

        this.state = {
            teamId: Number(props.match.params.teamId),
            team: null,
        };
    }

    componentDidMount() {
        let actionParameters: IActionParameters<TeamDto | null> = {
            action: () => new TeamClient().getTeam(this.state.teamId),
            onSuccess: (response) => {
                this.setState({
                    team: response,
                });
            },
        };

        SendActionWithResponse(actionParameters);
    }

    render() {
        return (
            <Container
                style={{
                    paddingBottom: "10vh",
                    paddingTop: "5vh",
                    color: "white"
                }}
            >
                <Row className="align-items-center">
                    <Col md="auto">
                        <Image src={this.state.team?.imageUrl}
                            width={250}
                            height={250} />
                    </Col>
                    <Col md="auto">
                        <h1>{this.state.team?.name}</h1>
                        <h3>{this.state.team?.acronym}</h3>
                    </Col>

                </Row>

            </Container>
        );
    }
}
export default withRouter(TeamStats);
