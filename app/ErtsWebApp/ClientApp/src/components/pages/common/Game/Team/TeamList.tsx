import React from "react";
import { Container, CardGroup } from "react-bootstrap";
import {
    TeamClient,
    TeamImageDto,
} from "../../../../../services/GeneratedClient";
import {
    IActionParameters,
    SendActionWithResponse,
} from "../../../../../_infrastructure/actions/SendAction";
import TeamListItem from "./TeamListItem";
import { RouteComponentProps } from "react-router-dom";
import GameNav from "../GameNav";

interface IProps { }

interface IPassedProps {
    gameType: string;
}

type IJoinedProps = IProps & RouteComponentProps<IPassedProps>;

interface IState {
    teams: TeamImageDto[] | null;
    gameType: string;
    key: string;
}

class TeamList extends React.Component<IJoinedProps, IState> {
    constructor(props: IJoinedProps) {
        super(props);

        this.state = {
            teams: null,
            gameType: props.match.params.gameType,
            key: "teams"
        };
    }

    componentDidMount() {
        var fragment = new URLSearchParams(this.props.location.search).get("fragment")?.toString() ?? "";
        this.getTeamImages(fragment);
    }

    getTeamImages(fragment: string) {
        let actionParameters: IActionParameters<TeamImageDto[] | null> = {
            action: () => new TeamClient().getTeamImages(this.state.gameType, fragment.toLowerCase()),
            onSuccess: (response) => {
                this.setState({
                    teams: response
                });
            },
        };
        SendActionWithResponse(actionParameters);
    }

    render() {
        return (
            this.state.teams && (
                <Container style={{ paddingBottom: "10vh", paddingTop: "5vh", paddingRight: "18vh", paddingLeft: "17vh" }}>
                    <GameNav activeKey={"teams"} gameType={this.state.gameType} onHandleEvent={(fragment) => this.getTeamImages(fragment)} />

                    <CardGroup>
                        {this.state.teams.map((team, i) => (
                            <span style={{ padding: "2vh" }} key={team.id}>
                                <TeamListItem
                                    gameType={this.state.gameType}
                                    teamImageDto={team}
                                />
                            </span>
                        ))}
                    </CardGroup>
                </Container>
            )
        );
    }
}
export default TeamList;