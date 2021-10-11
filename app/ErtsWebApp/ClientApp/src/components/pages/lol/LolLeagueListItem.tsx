import { Image } from "react-bootstrap";
import { useHistory } from "react-router";

function LolLeagueListItem(props: { leagueImg: any; leagueId: number }) {
	let history = useHistory();

	const redirectToPage = (page: string) => {
		history.push(page);
	}

	var leagueImg = props.leagueImg;
	var leagueId = props.leagueId;
	return (

		<Image src={leagueImg} rounded
			width={150}
			height={150}
			onClick={() => redirectToPage(`lol/${leagueId}`)} />

	);
}

export default LolLeagueListItem;
