import React from "react";
import { Container } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";
import "../../../../css/myStyle.css";
import {
    LolTournamentTeamStatsDto,
    TournamentClient,
} from "../../../../services/GeneratedClient";
import {
    IActionParameters,
    SendActionWithResponse,
} from "../../../../_infrastructure/actions/SendAction";
import TournamentNav from "../../common/Tournament/TournamentNav";
import LolTournamentTeamStatsListTable from "./LolTournamentTeamStatsListTable";

interface IProps { }

interface IPassedProps {
    tournamentId: string;
}

interface IState {
    tournamentId: number;
    teamStatsList: LolTournamentTeamStatsDto[] | null;
    key: string;
}

type IJoinedProps = IProps & RouteComponentProps<IPassedProps>;

class LolTournamentTeamStatsList extends React.Component<
    IJoinedProps,
    IState
> {
    constructor(props: IJoinedProps) {
        super(props);

        this.state = {
            tournamentId: Number(props.match.params.tournamentId),
            teamStatsList: null,
            key: "team-stats",
        };
    }

    componentDidMount() {
        let actionParameters: IActionParameters<
            LolTournamentTeamStatsDto[] | null
        > = {
            action: () =>
                new TournamentClient().getLolTournamentTeamStats(
                    this.state.tournamentId
                ),
            onSuccess: (response) => {
                this.setState({
                    teamStatsList: response,
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
                }}
            >
                <TournamentNav activeKey={this.state.key} gameType="lol" />
                <LolTournamentTeamStatsListTable
                    teamStatsList={this.state.teamStatsList}
                />
            </Container>
        );
    }
}
export default withRouter(LolTournamentTeamStatsList);