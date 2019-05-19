import * as React from 'react';
interface IProps {
    countBy?: number;
}

interface IState {
    selectedProductId: number;
    selectedGroupId: number;
    products: { productId: number, name: string }[];
}

class Issue extends React.Component<IProps, IState> {
    constructor(props: IProps) {
        super(props);

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        
        this.api<[{ productId: number; name: string }]>('https://localhost:44345/issues/GetProducts?groupId=1')
            .then((products: [{ productId: number, name: string }]) => {
                this.state.products = products;
            })
            .catch(error => {
                /* show error message */
            });
    }

    state: IState = {
        products: [],
        selectedGroupId: 0,
        selectedProductId: 0
    };

    api<T>(url: string): Promise<T> {
        return fetch(url)
            .then(response => {
                if (!response.ok) {
                    throw new Error(response.statusText);
                }
                return response.json() as Promise<T>;
            });
    }

    handleChange(event: any) {
        this.setState({ selectedProductId: event.target.value });
    }

    handleSubmit(event: any) {
        alert('Your favorite flavor is: ' + this.state.selectedProductId);
        event.preventDefault();
    }

    getOptions = () => {
        let options = [];
        for (let product of this.state.products) {
            let opt = document.createElement("option");
            opt.value = product.productId.toString();
            opt.innerHTML = product.name;
            options.push(opt);
        }
        return options;
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <label>
                    Pick your favorite flavor:
                    <select value={this.state.selectedProductId} onChange={this.handleChange}>
                        {this.getOptions()}
                    </select>
                </label>
                <input type="submit" value="Submit" />
            </form>
        );
    }
}

export default Issue;