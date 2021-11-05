import React from "react";
import { Container, Col, Row, Image } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";
import "../../../../css/myStyle.css";
import { TeamClient, TeamDto } from "../../../../services/GeneratedClient";
import {
    IActionParameters,
    SendActionWithResponse,
} from "../../../../_infrastructure/actions/SendAction";
import TeamInfo from "./TeamInfo";
import PlayerList from "./PlayerList";
import LastMatches from "./LastMatches";
import UpcomingMatches from "./UpcomingMatches";

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
                <TeamInfo team={this.state.team} />
                <Row>
                    <Col>
                        <PlayerList players={this.state.team?.players} />
                    </Col>
                </Row>
                <Row>
                    <Col md="auto">
                        <LastMatches lastMatches={this.state.team?.lastMatches} />
                    </Col>
                    <Col md="auto">
                        <UpcomingMatches upcomingMatches={this.state.team?.upcomingMatches} />
                    </Col>
                </Row>


            </Container >
        );
    }
}
export default withRouter(TeamStats);
