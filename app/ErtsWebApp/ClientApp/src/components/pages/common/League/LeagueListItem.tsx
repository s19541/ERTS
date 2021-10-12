import { Image } from "react-bootstrap";
import { useHistory } from "react-router";

function LeagueListItem(props: { gameType: string; leagueImg: any; leagueId: number }) {
	let history = useHistory();

	const redirectToPage = (page: string) => {
		history.push(page);
	}

	var gameType = props.gameType;
	var leagueImg = props.leagueImg;
	var leagueId = props.leagueId;
	return (

		<Image src={leagueImg} rounded
			width={150}
			height={150}
			onClick={() => redirectToPage(`${gameType}/${leagueId}`)} />

	);
}

export default LeagueListItem;
