import React from "react";
import { Container } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";
import "../../../../css/myStyle.css";
import {
	LolTournamentPlayerStatsDto,
	TournamentClient,
} from "../../../../services/GeneratedClient";
import {
	IActionParameters,
	SendActionWithResponse,
} from "../../../../_infrastructure/actions/SendAction";
import TournamentNav from "../../common/Tournament/TournamentNav";
import LolTournamentPlayerStatsListTable from "./LolTournamentPlayerStatsListTable";

interface IProps { }

interface IPassedProps {
	tournamentId: string;
}

interface IState {
	tournamentId: number;
	playerStatsList: LolTournamentPlayerStatsDto[] | null;
	key: string;
}

type IJoinedProps = IProps & RouteComponentProps<IPassedProps>;

class LolTournamentPlayerStatsList extends React.Component<
	IJoinedProps,
	IState
> {
	constructor(props: IJoinedProps) {
		super(props);

		this.state = {
			tournamentId: Number(props.match.params.tournamentId),
			playerStatsList: null,
			key: "player-stats",
		};
	}

	componentDidMount() {
		let actionParameters: IActionParameters<
			LolTournamentPlayerStatsDto[] | null
		> = {
			action: () =>
				new TournamentClient().getLolTournamentPlayerStats(
					this.state.tournamentId
				),
			onSuccess: (response) => {
				this.setState({
					playerStatsList: response,
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
				<LolTournamentPlayerStatsListTable
					playerStatsList={this.state.playerStatsList}
				/>
			</Container>
		);
	}
}
export default withRouter(LolTournamentPlayerStatsList);
